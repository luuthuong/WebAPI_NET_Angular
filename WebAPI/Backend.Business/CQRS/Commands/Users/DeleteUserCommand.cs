using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Business.CQRS.Commands.Users
{
    public class DeleteUserCommand: IRequest<ResponseBase<bool>>
    {
        public Guid UserId { get; set; }
        public class DeleteUserCommandHandler : ServiceBase, IRequestHandler<DeleteUserCommand, ResponseBase<bool>>
        {
            private readonly UserManager<User> _usermanager;
            public DeleteUserCommandHandler(
                AppDbContext dbContext,
                ILogger<DeleteUserCommandHandler> logger,
                IMapper mapper,
                UserManager<User> usermanager) : base(dbContext, logger, mapper)
            {
                _usermanager = usermanager;
            }
            public async Task<ResponseBase<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await DBContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
                if (user == null)
                {
                    return new ResponseBase<bool>
                    {
                        Message = "User not found",
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                var result = await _usermanager.DeleteAsync(user);
                return new ResponseBase<bool>
                {
                    Message = result.Succeeded ? "Delete user success." : "Delete user fail",
                    ResponseStatus = result.Succeeded ? ResponseStatusEnum.Success : ResponseStatusEnum.Error,
                    Data = result.Succeeded
                };
            }
        }
    }
}
