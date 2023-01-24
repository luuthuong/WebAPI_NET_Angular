using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.CQRS.Queries.Blogs
{
    public class GetBlogByIdQuery: IRequest<ResponseBase<BlogModel>>
    {
        public Guid BlogId { get; set; }
        public class GetBlogByIdQueryHandler : ServiceBase, IRequestHandler<GetBlogByIdQuery, ResponseBase<BlogModel>>
        {
            public GetBlogByIdQueryHandler(
                AppDbContext dbContext, 
                ILogger<GetBlogByIdQueryHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper)
            {
            }

            public async Task<ResponseBase<BlogModel>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
            {
                var blog = await DBContext.Blog.FirstOrDefaultAsync(x => x.Id == request.BlogId);
                if(blog == null)
                {
                    return new ResponseBase<BlogModel>
                    {
                        ResponseStatus = ResponseStatusEnum.Error,
                        Message = "Blog not found"
                    };
                }
                return new ResponseBase<BlogModel>
                {
                    ResponseStatus =  ResponseStatusEnum.Success ,
                    Data = Mapper.Map<Blog, BlogModel>(blog),
                };
            }
        }
    }
}
