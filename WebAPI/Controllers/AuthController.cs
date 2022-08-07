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
        private readonly IUserServices _userServices;
        private readonly IAuthenticationServices _authenticationServices;
        public AuthController(
            IUserServices userServices, 
            IAuthenticationServices authenticationServices
         )
        {
            _userServices = userServices;
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

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(AuthenticatedResponseDTO token)
        {
            var result = await _authenticationServices.RefreshToken(token);
            return Ok(result);
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userServices.GetAllUsers());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var result = _userServices.GetUserById(id);
            if (result == null)
                return NotFound("Not Found");
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO newUser)
        {
            var result = await _userServices.RegisterUser(newUser);
            if (!result.Succeeded)
            {
                var err = result.Errors;
                return BadRequest(err);
            }
            return Ok(result.Succeeded);
        }

        [HttpPut("update")]
        public void UpdateUser(int id, [FromBody] string value)
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
