using DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;
using Services.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        public IActionResult Get()
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
        public string Get(int id)
        {
            return "value";
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

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
