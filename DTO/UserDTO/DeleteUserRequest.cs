﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class DeleteUserRequest
    {
        public string? UserId { get; set; }
        public string? Password { get; set; }
    }
}
