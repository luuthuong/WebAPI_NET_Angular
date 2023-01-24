using Backend.Business.CQRS.Commands.Blogs;
using Backend.Business.CQRS.Queries.Blogs;
using Backend.Common.Models;
using Backend.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public Task<ResponseBase<BlogModel>> Create(CreateBlogCommand request )
        {
            request.UserId = User.GetUserId();
            return _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public Task<ResponseBase<BlogModel>> GetBlogById(Guid id)
        {
            return _mediator.Send(new GetBlogByIdQuery
            {
                BlogId = id
            });
        }

        [HttpGet("list-blog")]
        public Task<PagingResultModel<IList<BlogModel>>> GetPagingBlog([FromQuery]PagingParamenters<BlogFilter> pagingParamenters)
        {
            return _mediator.Send(new GetPagingBlogQuery
            {
                PagingParamenters = pagingParamenters
            });
        }

        [HttpPut("{id}")]
        public Task<ResponseBase<BlogModel>> UpdateBlog(Guid id, [FromBody] UpdateBlogModel request)
        {
            return _mediator.Send(new UpdateBlogCommand
            {
                UserId = User.GetUserId(),
                BlogId = id,
                BlogUpdate = request
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseBase<bool>> DeleteBlog(Guid id)
        {
            return _mediator.Send(new DeleteBlogCommand
            {
                BlogId = id
            });
        }

    }
}
