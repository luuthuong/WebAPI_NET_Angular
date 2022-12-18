using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Business.CQRS.Queries.Users
{
    public class GetPagingUserQuery: IRequest<ResponseBase<PagingResultModel<UserModel>>>
    {
        public PagingParamenters<UserFilterModel> PagingParameter;
        public class GetPagingUserQueryHandler :ServiceBase, IRequestHandler<GetPagingUserQuery, ResponseBase<PagingResultModel<UserModel>>>
        {
            public GetPagingUserQueryHandler(
                AppDbContext dbContext, 
                ILogger<GetPagingUserQueryHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper)
            {

            }

            public async Task<ResponseBase<PagingResultModel<UserModel>>> Handle(GetPagingUserQuery request, CancellationToken cancellationToken)
            {
                var pagingParameter = request.PagingParameter;

                var query = DBContext.Users.Include(usr => usr.UserRoles).AsNoTracking().Where(usr => usr.Status != StatusEnum.Deleted && usr.Status != StatusEnum.InActive);
                query = ApplyFilter(query, pagingParameter);
                var result = await ApplyOrder(query, pagingParameter.OrderBy).CreatePagingResultAsync(pagingParameter);
                var userModels = Mapper.Map<List<User>, List<UserModel>>(result.Data.ToList());
                var pagingResult = Mapper.MapPagingResult<User, UserModel>(result);
                await MappingRolesForUser(pagingResult.Data.ToList());
                return new ResponseBase<PagingResultModel<UserModel>>
                {
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = pagingResult
                };
            }

            public async Task MappingRolesForUser(List<UserModel> userModels)
            {
                var userIds = userModels.Select(x => x.Id).ToList();
                if (!userIds.Any())
                {
                    return;
                }
                var userRoles = await DBContext.UserRoles.Where(x => userIds.Contains(x.UserId)).Include(x => x.Role).ToListAsync();
                var userRoleDictionary = userRoles.GroupBy(x => x.UserId).ToDictionary(x => x.Key, x => x.ToList());
                foreach (var userModel in userModels)
                {
                    var userRole = userRoleDictionary.GetValueOrDefault(userModel.Id);
                    userModel.Roles = (userRole ?? new List<UserRole>()).Select(x => new RoleModel
                    {
                        Id = x.RoleId,
                        Name = x.Role.Name ?? string.Empty
                    }).ToList();
                }
            }

            private IQueryable<User> ApplyFilter(IQueryable<User> query, PagingParamenters<UserFilterModel> pagingParamenters)
            {
                var searchText = pagingParamenters.Filter.SearchText ?? string.Empty;
                if(!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(x => EF.Functions.Like(x.DisplayName, $"%{searchText}%"));
                }
                return query;
            }
            private IQueryable<User> ApplyOrder(IQueryable<User> query, PagingOrderModel orderBy)
            {
                var orderByName = FirstCharToUpper(orderBy.Name) ?? string.Empty;
                if (orderByName.Equals("Notifications"))
                {
                    return ApplyOrderForNotifications(query, orderBy);
                }
                return base.ApplyOrder(query, orderBy, fieldName =>
                {
                    switch (fieldName)
                    {
                        case "Email":
                            return entity => entity.Email;
                        case "CreatedDate":
                            return entity => entity.CreatedDate;
                        case "UpdatedDate":
                            return entity => entity.UpdatedDate;
                        default:
                            return default;
                    }
                });
            }

            private IQueryable<User> ApplyOrderForNotifications(IQueryable<User> query, PagingOrderModel orderBy)
            {
                    return orderBy.Direction == OrderDirectionEnum.DESC ? query.OrderByDescending(x => x.EnableEmailNotification) : query.OrderBy(x => x.EnableEmailNotification);
            }
        }
    }
}
