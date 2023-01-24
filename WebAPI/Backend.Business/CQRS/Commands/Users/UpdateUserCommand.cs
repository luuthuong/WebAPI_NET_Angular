using AutoMapper;
using Backend.Business.CQRS.Queries.Users;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.CQRS.Commands.Users
{
    public class UpdateUserCommand: IRequest<ResponseBase<UserModel>>
    {
        public Guid Id { get; set; }
        public UserUpdateModel UserUpdate { get; set; }
        public class UpdateUserCommandHandler : ServiceBase, IRequestHandler<UpdateUserCommand, ResponseBase<UserModel>>
        {
            private readonly IMediator _mediator;
            public UpdateUserCommandHandler(
                AppDbContext dbContext, 
                ILogger<UpdateUserCommandHandler> logger, 
                IMapper mapper,
                IMediator mediator
                ) : base(dbContext, logger, mapper)
            {
                _mediator = mediator;
            }

            public async Task<ResponseBase<UserModel>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                
                var validUserResponse = await _mediator.Send(new ValidUserQuery
                {
                    Email = request.UserUpdate.Email,
                    UserId = request.Id
                });
                if(validUserResponse.ResponseStatus == ResponseStatusEnum.Error)
                {
                    return new ResponseBase<UserModel>
                    {
                        ResponseStatus = ResponseStatusEnum.Error,
                        Message = validUserResponse.Message
                    };
                }
                var user = await DBContext.Users.Include(usr => usr.UserRoles).FirstOrDefaultAsync(usr => usr.Id == request.Id);
                if (user == null)
                {
                    return new ResponseBase<UserModel>()
                    {
                        Message = "User not found",
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                user = Mapper.Map<UserUpdateModel, User>(request.UserUpdate);
                user.UserRoles = (request.UserUpdate.RoleIds ?? new List<Guid>()).Select(x => new UserRole
                {
                    RoleId = x,
                }).ToList();
                await DBContext.SaveChangesAsync();
                return new ResponseBase<UserModel>
                {
                    Message = "Update success",
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = Mapper.Map<UserModel>(user)
                };
            }
        }
    }
}
