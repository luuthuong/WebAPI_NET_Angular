using Common.Helper;
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
        public IActionResult Get([FromQuery]int page)
        {
            var pagination = PaginationList<FileDTOModel>.Create(_services.GetAllFile().ToList(), page, 10);
            var result = page > 0 ? pagination : _services.GetAllFile();

            return Ok(new ResponseBaseDTO<IEnumerable<FileDTOModel>>
            {
                Status = StatusCodes.Status200OK,
                Message = "Success",
                Total = pagination.TotalPage,
                Page = pagination.PageIndex,
                Response = result
            }); 
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

        [HttpPost("PostMultileFile")]
        public async Task<IActionResult> PostMultiFile(IEnumerable<IFormFile> files)
        {
            bool result = await _services.AddMultiFile(files);
            if (!result) return BadRequest(new ResponseBaseDTO
            {
                Status = StatusCodes.Status502BadGateway,
                Message = "Upload file Fail"
            });
            return Ok(new ResponseBaseDTO<IEnumerable<IFormFile>>
            {
                Status = StatusCodes.Status200OK,
                Message = "Upload file success",
                Total =files.Count(),
                Response = files
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
