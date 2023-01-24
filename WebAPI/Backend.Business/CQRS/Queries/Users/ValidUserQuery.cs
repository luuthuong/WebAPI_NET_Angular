using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Business.CQRS.Queries.Users
{
    public class ValidUserQuery: IRequest<ResponseBase<bool>>
    {
        public Guid UserId { get; set; } 
        public string Email { get;set; }
        public class ValidUserQueryHandler : ServiceBase, IRequestHandler<ValidUserQuery, ResponseBase<bool>>
        {
            public ValidUserQueryHandler(
                AppDbContext dbContext, 
                ILogger<ValidUserQueryHandler> logger, 
                IMapper mapper
                ) : base(dbContext, logger, mapper){
            }

            public async Task<ResponseBase<bool>> Handle(ValidUserQuery request, CancellationToken cancellationToken)
            {
                string email = request.Email.Trim() ?? string.Empty;
                Guid userId = request?.UserId ?? Guid.Empty;
                if(string.IsNullOrEmpty(email))
                {
                    return new ResponseBase<bool>()
                    {
                        Message = "Email is required",
                        ResponseStatus = ResponseStatusEnum.Error,
                        Data = false
                    };
                }
                var predicate = PredicateBuilder.New<User>().And(usr => usr.Status == StatusEnum.Active && usr.Email == email);
                predicate = predicate.And(usr => usr.Id != userId);
                var existed = await DBContext.Users.AnyAsync(predicate);
                return new ResponseBase<bool> { 
                    ResponseStatus = existed ? ResponseStatusEnum.Error : ResponseStatusEnum.Success,
                    Message = existed ? "Email already exists." : string.Empty,
                    Data = existed
                };
            }
        }
    }
}
