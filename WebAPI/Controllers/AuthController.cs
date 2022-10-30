using Common;
using Common.Interface;
using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;
using Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Token.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;
        private readonly ITokenService _tokenService;
        private readonly ILoggerManager _logger;

        public AuthController(
            IAuthenticationServices authenticationServices,
            ITokenService tokenService,
            ILoggerManager logger
        )
        {
            _authenticationServices = authenticationServices;
            _tokenService = tokenService;
            _logger = logger;
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

        [HttpGet("CheckExpiredToken")]
        public bool CheckExpiredToken()
        {
            return _authenticationServices.CheckExpiredToken(_tokenService.GetCurrentToken());
        }

        [HttpPost("LogOut")]
        public IActionResult LogOut()
        {
            //var result =_authenticationServices.LogOut();
            //if (result.IsCompleted)
            //{
            //    return Ok("Dang xuat thanh cong");
            //}
            //return BadRequest("Dang xuat that bai");
            return Ok(new
            {
                Id = _tokenService.ResolveUserId(),
                Email = _tokenService.ResolveUserEmail(),
                Name = _tokenService.ResolveUserName()
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(AuthenticatedResponseDTO token)
        {
            var result = await _authenticationServices.RefreshToken(token);
            return Ok(result);
        }

    }
}
