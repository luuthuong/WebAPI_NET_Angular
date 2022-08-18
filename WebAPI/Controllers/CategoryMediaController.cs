using DTO;
using DTO.MediaCategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryMediaController : ControllerBase
    {
        private readonly IMediaCategoryServices _services;
        public CategoryMediaController(IMediaCategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _services.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult Get([FromQuery]string id)
        {
            var result = _services.GetById(id);
            if(result == null)
                return NotFound(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Category Not Found"
                });
            return Ok(new ResponseBaseDTO<MediaCategoryDTOModel>
            {
                Status = StatusCodes.Status200OK,
                Message="Success",
                Response = result
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMediaCategoryRequest request)
        {
            var result = _services.Create(request);
            if (!result) 
                return BadRequest(
                    new ResponseBaseDTO
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Create Fail"
                    });

            return Ok(new ResponseBaseDTO<CreateMediaCategoryRequest>
            {
                Status = StatusCodes.Status200OK,
                Message = "Create Success",
                Response = request
            });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] UpdateMediaCategoryRequest request)
        {
            bool result =await _services.Update(request);
            if (request.Id == null || !result) return BadRequest("Update Fail");
            var category = _services.GetById(request.Id);
            return Ok(new ResponseBaseDTO<MediaCategoryDTOModel>
            {
                Status = StatusCodes.Status200OK,
                Message = "Update Success",
                Response = category
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]string id)
        {
            bool result = await _services.Delete(id);
            if (!result) return BadRequest("Delete Fail");
            return Ok(new ResponseBaseDTO
            {
                Status = StatusCodes.Status200OK,
                Message = "Category was deleted"
            });
        }

        [HttpGet("GetChildrens")]
        public IActionResult GetChildrens(string id)
        {
            try
            {
                var result = _services.GetChildren(id);
                return Ok(result);
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

        [HttpGet("GetFileById")]
        public IActionResult GetFileById([FromQuery]GetFilesInCategoryRequest request)
        {
            try
            {
                return Ok(_services.GetFilesInCategory(request));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("SearchCategory")]
        public IActionResult SearchCategory([FromQuery] SearchCategoryRequest request)
        {
            try
            {
                var result = _services.SearchCategory(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
