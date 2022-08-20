using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Blog;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IPostService _service;
        public BlogPostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPost")]
        public IActionResult GetAllPost()
        {
            return Ok("Ok");
        }
    }
}
