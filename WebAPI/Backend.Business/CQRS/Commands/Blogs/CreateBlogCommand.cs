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
    public class CreateBlogCommand: UpdateBlogModel, IRequest<ResponseBase<BlogModel>>
    {
        public Guid UserId { get; set; }
        public class CreateBlogCommandHandler : ServiceBase, IRequestHandler<CreateBlogCommand, ResponseBase<BlogModel>>
        {
            public CreateBlogCommandHandler(
                AppDbContext dbContext, 
                ILogger<CreateBlogCommandHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper)
            {
            }

            public async Task<ResponseBase<BlogModel>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                var user = await DBContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
                if(user is null)
                {
                    return new ResponseBase<BlogModel>()
                    {
                        ResponseStatus = ResponseStatusEnum.Error,
                        Message = "User not exist"
                    };
                }
                var newBlog = Mapper.Map<UpdateBlogModel, Blog>(request);
                newBlog.CreateBy = request.UserId;
                await DBContext.Blog.AddAsync(newBlog);
                await DBContext.SaveChangesAsync(cancellationToken);
                return new ResponseBase<BlogModel>
                {
                    ResponseStatus = ResponseStatusEnum.Success,
                    Data = Mapper.Map<Blog, BlogModel>(newBlog)
                };
            }
        }
    }
}
