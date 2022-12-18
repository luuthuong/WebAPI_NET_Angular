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
    public class GetUserByIdQuery : IRequest<ResponseBase<UserModel>>
    {
        public Guid UserId { get; set; }
        public class GetUserByIdQueryHandler : ServiceBase, IRequestHandler<GetUserByIdQuery, ResponseBase<UserModel>>
        {
            public GetUserByIdQueryHandler(
                AppDbContext dbContext,
                ILogger<GetUserByIdQueryHandler> logger,
                IMapper mapper
                ) : base(dbContext, logger, mapper) { }

            public async Task<ResponseBase<UserModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await DBContext.Users.FirstOrDefaultAsync(usr => usr.Id == request.UserId);
                if (user == null)
                {
                    return new ResponseBase<UserModel>()
                    {
                        Message = "User not found",
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                return new ResponseBase<UserModel>
                {
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = Mapper.Map<User,UserModel>(user)
                };
            }
        }
    }
}
