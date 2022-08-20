using DTO.UserDTO;
using Microsoft.AspNetCore.Authentication;
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpGet("claim")]
        public IActionResult GetUserClaim()
        {
            return Ok(_userServices.GetUserClaim());
        }

        [Authorize]
        [HttpPut("updateUserById")]
        public async Task<IActionResult> UpdateUser(string id , UpdateUserRequest request)
        {
           var result = await _userServices.UpdateUser(id, request);
           return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userServices.DeleteUser(id);
            if (!result)
            {
                return BadRequest("Delete Fail");
            }
            return Ok(new
            {
                Status = "User was deleted",
                Id = id
            });
        }
    }
}
