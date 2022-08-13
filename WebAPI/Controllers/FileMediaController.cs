using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileMediaController : ControllerBase
    {
        private readonly IFileMediaServices _services;
        public FileMediaController(IFileMediaServices services)
        {
            _services = services;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post( [FromForm] IFormFile request)
        {
            using (var ms = new MemoryStream())
            {
                request.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                string strConvert = Convert.ToBase64String(fileBytes);
                return Ok(fileBytes);
            }
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
