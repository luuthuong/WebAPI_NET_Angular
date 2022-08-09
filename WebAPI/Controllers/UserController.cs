using DTO.UserDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getAll")]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult GetUserById([FromQuery]string id)
        {
            var result = _userServices.GetUserById(id);
            if (result == null)
                return NotFound("Not Found");
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest newUser)
        {
            var result = await _userServices.RegisterUser(newUser);
            if (!result.Succeeded)
            {
                var err = result.Errors;
                return BadRequest(err);
            }
            return Ok(result.Succeeded);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("update")]
        public void UpdateUser(string Id,[FromBody] UpdateUserRequest request)
        {

        }

        [HttpGet("claim")]
        public IActionResult GetUserClaim()
        {
            return Ok(_userServices.GetUserClaim());
        }

        [HttpDelete]
        public void DeleteUser(DeleteUserRequest request)
        {
        }
    }
}
