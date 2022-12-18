using Backend.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.CQRS.Commands.Users
{
    public class DeleteUserCommand: IRequest<ResponseBase<bool>>
    {
        public Guid UserId { get; set; }
    }
}
