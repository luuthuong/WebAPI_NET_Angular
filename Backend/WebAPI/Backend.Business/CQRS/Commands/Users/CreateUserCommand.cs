﻿using Backend.Common.Models;
using Backend.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.CQRS.Commands.Users
{
    public class CreateUserCommand: IRequest<ResponseBase<UserModel>>
    {
    }
}