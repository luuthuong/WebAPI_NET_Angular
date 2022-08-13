using DTO;
using DTO.FileDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
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
        public IActionResult Get()
        {
            return Ok(new ResponseBaseDTO<IEnumerable<FileDTOModel>>
            {
                Status = StatusCodes.Status200OK,
                Message = "Success",
                Response = _services.GetAllFile()
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromForm]CreateFileRequest request)
        {
            bool result = _services.AddFileMedia(request);
            if (!result) return (BadRequest(new ResponseBaseDTO
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Upload file Fail"
            }));
            return Ok(new ResponseBaseDTO
            {
                Status = StatusCodes.Status200OK,
                Message = "Upload file success",
            });
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
