using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            return _repository.GetAll().AsEnumerable();
        }
        [HttpGet("get2")]
        public IActionResult GetPrimary()
        {
            return Ok("asdasdasd");
        }
        [HttpPost]
        public IActionResult Post(string name,string description)
        {
            var newCate = new CategoryModel()
            {
                Description = description,
                Name = name,
                Id = Guid.NewGuid()
            };
           var result = _repository.Create(newCate);
            return Ok(result);
        }
    }
}
