using Backend.Business.CQRS.Commands.Users;
using Backend.Business.CQRS.Queries.Users;
using Backend.Business.Services.Interfaces;
using Backend.Common.Constants;
using Backend.Common.Models;
using Backend.Common.Requests;
using Backend.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;
        public UserController(
            IMediator mediator,
            IAuthService authService
            ) 
        { 
            _mediator = mediator;
            _authService = authService;
        }


        [HttpGet("{id}")]
        public Task<ResponseBase<UserModel>> GetUserById(Guid id)
        {
            return _mediator.Send(new GetUserByIdQuery
            {
                UserId = id
            });
        }

        [HttpPost("create")]
        public Task<ResponseBase<UserModel>> CreateUser(RegisterUserRequest request)
        {
            return _mediator.Send(new CreateUserCommand
            {
                RegisterUser = request
            });
        }

        [HttpGet("list-users")]
        [Authorize(Roles = RoleConstants.Admin)]
        public Task<ResponseBase<PagingResultModel<UserModel>>> GetPagingUser([FromQuery]PagingParamenters<UserFilterModel> pagingParameter)
        {
            return _mediator.Send(new GetPagingUserQuery
            {
                PagingParameter = pagingParameter
            });
        }

        [HttpPut("{id}")]
        public Task<ResponseBase<UserModel>> UpdateUserById(Guid id, UserUpdateModel request)
        {
            return _mediator.Send(new UpdateUserCommand
            {
                Id = id,
                UserUpdate = request
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleConstants.Admin)]
        public Task<ResponseBase<bool>> DeleteUserById(Guid id)
        {
            return _mediator.Send(new DeleteUserCommand
            {
                UserId = id
            });
        }
    }
}
