﻿
namespace Backend.Common.Requests
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
