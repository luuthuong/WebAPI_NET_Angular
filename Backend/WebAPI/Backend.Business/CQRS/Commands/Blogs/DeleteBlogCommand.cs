using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Responses;
using Backend.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Business.CQRS.Commands.Blogs
{
    public class DeleteBlogCommand : IRequest<ResponseBase<bool>>
    {
        public Guid BlogId { get; set; }
        public class DeleteBlogCommandHandler: ServiceBase, IRequestHandler<DeleteBlogCommand,ResponseBase<bool>>
        {
            public DeleteBlogCommandHandler(
                AppDbContext dbContext, 
                ILogger<DeleteBlogCommandHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper)
            {
            }
            public async Task<ResponseBase<bool>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = await DBContext.Blog.FirstOrDefaultAsync(x => x.Id == request.BlogId);
                if (blog == null)
                {
                    return new ResponseBase<bool>()
                    {
                        Message = "Blog not found",
                        ResponseStatus = ResponseStatusEnum.Error
                    };
                }
                DBContext.Blog.Remove(blog);
                var result = await DBContext.SaveChangesAsync(cancellationToken);
                return new ResponseBase<bool>()
                {
                    Data = result > 0,
                    ResponseStatus = ResponseStatusEnum.Success
                };
            }
        }
    }
}
