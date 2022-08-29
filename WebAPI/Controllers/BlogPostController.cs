﻿using DTO;
using DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize]
        [HttpGet("GetAllPost")]
        public IActionResult GetAllPost()
        {
            var result = _service.GetAllPost();
            return Ok(result);
        }

        [HttpGet("GetPostOfCategory")]
        public IActionResult GetPostOfCategory(string categoryId)
        {
            var result = _service.GetPostOfCategory(categoryId);
            return Ok(result);
        }

        [HttpGet("GetPostById")]
        public IActionResult GetPostById(string id)
        {
            var result = _service.GetPostById(id);
            return Ok(result);
        }

        [HttpGet("GetPostOfUser")]
        public IActionResult GetPostOfUser(string userId)
        {
            var user = User;
            var result = _service.GetPostOfAuthor(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult CreatePost(CreatePostRequest request)
        {
            try
            {
               bool result =  _service.CreateNewPost(request);
                if (result) return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Created"
                });
                return BadRequest(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Fail"
                });
            }
            catch
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpPut]
        public IActionResult UpdatePost([FromQuery]string Id,UpdatePostRequest request)
        {
            try
            {
                bool result = _service.UpdatePost(Id, request);
                if (result) return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Updated"
                });
                return BadRequest(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Fail"
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        //[Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromQuery] IEnumerable<string> Ids, bool includeChildren = false)
        {
            try
            {
                var result = await _service.DeletePost(Ids, includeChildren);
                if (result) return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Delete Success"
                });
                return BadRequest(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Fail"
                });
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("DeletePostOfAuthor")]
        public async  Task<IActionResult> DeletePostOfAuthor(string authorId, bool includeChilren = false)
        {
            try
            {
                var result =await _service.DeletePostOfAuthor(authorId,includeChilren);
                if (result) return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Delete Success"
                });
                return BadRequest(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Fail"
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("DeletePostOfCategory")]
        public async Task<IActionResult> DeletePostOfCategory(string categoryId, bool includeChilren = false)
        {
            try
            {
                var result = await _service.DeletePostOfCategory(categoryId,includeChilren);
                if (result) return Ok(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Delete Success"
                });
                return BadRequest(new ResponseBaseDTO
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Fail"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
