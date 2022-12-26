using AutoMapper;
using Backend.Business.CQRS.Queries.Users;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.Common.Requests;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Backend.Business.CQRS.Commands.Users
{
    public class CreateUserCommand: IRequest<ResponseBase<UserModel>>
    {
        public RegisterUserRequest RegisterUser { get; set; }
        public class CreateUserCommandHandler : ServiceBase, IRequestHandler<CreateUserCommand, ResponseBase<UserModel>>
        {
            private readonly UserManager<User> _userManager;
            private readonly IMediator _mediator;
            public CreateUserCommandHandler(
                AppDbContext dbContext, 
                ILogger<CreateUserCommandHandler> logger, 
                IMapper mapper,
                UserManager<User> userManager,
                IMediator mediator
                ) : base(dbContext, logger, mapper){
                _userManager = userManager;
                _mediator = mediator;
            }

            public async Task<ResponseBase<UserModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var validEmail = await _mediator.Send(new ValidUserQuery
                {
                    Email = request.RegisterUser.Email
                });
                if(validEmail.ResponseStatus == ResponseStatusEnum.Error)
                {
                    return new ResponseBase<UserModel>
                    {
                        Message = validEmail.Message,
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                var newUser = Mapper.Map<RegisterUserRequest, User>(request.RegisterUser);
                var createResponse = await _userManager.CreateAsync(newUser, request.RegisterUser.Password);
                if (!createResponse.Succeeded)
                {
                    return new ResponseBase<UserModel>
                    {
                        Message = createResponse.ToString(),
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                if (request.RegisterUser.RoleIds != null &&request.RegisterUser.RoleIds.Any())
                {
                    newUser.UserRoles = request.RegisterUser.RoleIds.Select(x => new UserRole { RoleId = x }).ToList();
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, RoleTypeEnum.Reader.ToString());
                }
                await DBContext.SaveChangesAsync();
                return new ResponseBase<UserModel>
                {
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = Mapper.Map<User, UserModel>(newUser)
                };
            }

        }
    }
}
