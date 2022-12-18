using Backend.Business.Services.Interfaces;
using Backend.Common.Enums;
using Backend.Common.Requests;
using Backend.Common.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
           var result =  await _authService.LoginAsync(request);
            if(result.HttpStatusCode == HttpStatusCode.OK)
            {
                return Ok(result);
            }
            if(result.HttpStatusCode == HttpStatusCode.NotFound || result.HttpStatusCode == HttpStatusCode.Unauthorized) {
                return Unauthorized();
            }
            return BadRequest();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var roles = User.GetRoles();
                var result =await _tokenService.RefreshToken(request, roles);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("revoke-token")]
        public async Task<ResponseBase<bool>> RevokeToken([FromBody] RefreshTokenRequest request)
        {

            if (string.IsNullOrEmpty(request.RefreshToken))
            {
                return new ResponseBase<bool>
                {
                    Data = false,
                    Message = "Token is required",
                    ResponseStatus = ResponseStatusEnum.Error
                };
            }

            try
            {
                var result = await _tokenService.RevokeToken(request);
                return new ResponseBase<bool>
                {
                    Message = "Revoke success",
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = true
                };
            }
            catch ( Exception e)
            {
                return  new ResponseBase<bool>
                {
                    Data = false,
                    Message = e.Message,
                    ResponseStatus = ResponseStatusEnum.Error
                };
            }
        }

    }
}
