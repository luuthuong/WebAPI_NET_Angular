using Common.Helper;
using DTO;
using DTO.FileDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Services.Interface.Media;

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
        public IActionResult GetAll([FromQuery]int page)
        {
            var pagination = PaginationList<FileDTOModel>.Create(_services.GetAllFile().ToList(), page, 10);
            var result = page > 0 ? pagination : _services.GetAllFile();
            return Ok(new ResponseBaseDTO<IEnumerable<FileDTOModel>>
            {
                Status = StatusCodes.Status200OK,
                Message = "Success",
                TotalPage = pagination.TotalPage,
                Total = _services.GetAllFile().Count(),
                Page = pagination.PageIndex,
                Response = result
            }); 
        }

        [HttpPost("AddFilesMedia")]
        public async Task<IActionResult> AddFilesMedia([FromForm] CreateFileRequest files)
        {
            bool result = await _services.AddFilesMedia(files);
            if (!result) return BadRequest(new ResponseBaseDTO
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Upload file Fail"
            });
            return Ok(new ResponseBaseDTO<CreateFileRequest>
            {
                Status = StatusCodes.Status200OK,
                Message = "Upload file success",
                Total =files.File?.Count(),
                Response = files
            });
        }

        [HttpPut("UpdateFile")]
        public async Task<IActionResult> Put(UpdateFileRequest request)
        {
            var result =await _services.UpdateFileMedia(request);
            if (result)
            {
                return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Update File Success"
                });
            }
            return BadRequest(new ResponseBaseDTO
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Error"
            });
        }

        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> Delete(DeleteFileRequest request)
        {
            var result = await _services.DeleteFileMedia(request);
            if (result)
            {
                return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Delete File Success"
                });
            }
            return BadRequest(new ResponseBaseDTO
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "Error"
            });
        }

        [HttpPost("SearchFile")]
        public IActionResult SearchFile(SearchFileRequest request)
        {
            try
            {
                return Ok(_services.SearchFile(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
}
