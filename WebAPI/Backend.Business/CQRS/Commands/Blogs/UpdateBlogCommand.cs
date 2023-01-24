using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Business.CQRS.Commands.Blogs
{
    public class UpdateBlogCommand: IRequest<ResponseBase<BlogModel>>
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public UpdateBlogModel BlogUpdate { get; set; }
        public class UpdateBlogCommandHandler : ServiceBase, IRequestHandler<UpdateBlogCommand, ResponseBase<BlogModel>>
        {
            public UpdateBlogCommandHandler(
                AppDbContext dbContext, 
                ILogger<UpdateBlogCommandHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper)
            {
            }

            public async Task<ResponseBase<BlogModel>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = await DBContext.Blog.FirstOrDefaultAsync(x => x.Id == request.BlogId);
                if (blog == null)
                {
                    return new ResponseBase<BlogModel>
                    {
                        Message = "Blog not exist",
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                blog = Mapper.Map<UpdateBlogModel, Blog>(request.BlogUpdate, blog);
                blog.UpdateBy = request.UserId;
                DBContext.Blog.Update(blog);
                return new ResponseBase<BlogModel>
                {
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = Mapper.Map<Blog,BlogModel>(blog)
                };
            }
        }
    }
}
