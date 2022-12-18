using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Guid userId = request.UserId;
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
