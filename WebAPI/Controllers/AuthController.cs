using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;
using Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;
        public AuthController(
            IAuthenticationServices authenticationServices
         )
        {
            _authenticationServices = authenticationServices;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
          var token = await _authenticationServices.Login(login);
            if (token == null)
            {
                return BadRequest("Login Fail");
            }
            return Ok(
                new
                {
                    status = "Dang nhap thanh cong",
                    token = token
                }
            );
        }

        [HttpPost("LogOut")]
        public IActionResult LogOut()
        {
            var result =_authenticationServices.LogOut();
            if (result.IsCompleted)
            {
                return Ok("Dang xuat thanh cong");
            }
            return BadRequest("Dang xuat that bai");
        }

        [Authorize]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(AuthenticatedResponseDTO token)
        {
            var result = await _authenticationServices.RefreshToken(token);
            return Ok(result);
        }

    }
}
