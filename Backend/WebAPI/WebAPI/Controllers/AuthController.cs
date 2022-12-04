using Backend.Business.Services.Interfaces;
using Backend.Common.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var token = Request.Headers["authorization"];
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Request.Headers["authorization"]);
        }
    }
}
