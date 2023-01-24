using AutoMapper;
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
    public class GetPagingBlogQuery: IRequest<PagingResultModel<IList<BlogModel>>>
    {
        public PagingParamenters<BlogFilter> PagingParamenters { get; set; }
        public class GetPagingBlogQueryHandler : ServiceBase, IRequestHandler<GetPagingBlogQuery, PagingResultModel<IList<BlogModel>>>
        {
            public GetPagingBlogQueryHandler(
                AppDbContext dbContext, 
                ILogger<GetPagingBlogQueryHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper){}

            public async Task<PagingResultModel<IList<BlogModel>>> Handle(GetPagingBlogQuery request, CancellationToken cancellationToken)
            {
                var query = DBContext.Blog.Include(x => x.Category).AsQueryable<Blog>();
                query = ApplyFilter(query, request.PagingParamenters);
                var pagingResult = await ApplyOrder(query, request.PagingParamenters.OrderBy).CreatePagingResultAsync(request.PagingParamenters);
                return Mapper.MapPagingResult<Blog,IList<BlogModel>>(pagingResult);
            }

            private IQueryable<Blog> ApplyFilter(IQueryable<Blog> query, PagingParamenters<BlogFilter> pagingParamenters)
            {
                string searchText = pagingParamenters.Filter?.SearchText.Trim() ?? string.Empty;
                if(!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(x => EF.Functions.Like(x.Title, $"%{searchText}%"));
                }
                query = pagingParamenters.Filter is not null ? query.Where(x => x.CategoryId == pagingParamenters.Filter.CategoryId) : query;
                return query;
            }

            private IQueryable<Blog> ApplyOrder(IQueryable<Blog> query, PagingOrderModel pagingOrder)
            {
                return base.ApplyOrder<Blog>(query, pagingOrder, fieldName =>
                {
                    return fieldName switch
                    {
                        "MetaTitle" => entity => entity.MetaTitle,
                        "Slug" => entity => entity.Slug,
                        _ => entity => entity.Title
                    };
                });
            }
        }
    }
}
