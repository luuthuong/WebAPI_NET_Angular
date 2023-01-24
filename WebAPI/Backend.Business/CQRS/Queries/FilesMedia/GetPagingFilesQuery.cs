using AutoMapper;
using Backend.Common.Models;
using Backend.DBContext;
using Backend.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.CQRS.Queries.FilesMedia
{
    public class GetPagingFilesQuery: IRequest<PagingResultModel<FileModel>>
    {
        public PagingParamenters<FileFilterModel> pagingParamenters;
        public class GetPagingFilesQueryHandler : ServiceBase, IRequestHandler<GetPagingFilesQuery, PagingResultModel<FileModel>>
        {
            public GetPagingFilesQueryHandler(
                AppDbContext dbContext, 
                ILogger<GetPagingFilesQueryHandler> logger, 
                IMapper mapper) : base(dbContext, logger, mapper)
            {
            }

            public async Task<PagingResultModel<FileModel>> Handle(GetPagingFilesQuery request, CancellationToken cancellationToken)
            {
                var pagingParameters = request.pagingParamenters;
                var query = ApplyFilter(DBContext.File, pagingParameters);
                var pagingResult = await ApplyOrder(query, pagingParameters.OrderBy).CreatePagingResultAsync(pagingParameters);
                return Mapper.MapPagingResult<FileMedia,FileModel>(pagingResult);
            }

            private IQueryable<FileMedia> ApplyFilter(IQueryable<FileMedia> query, PagingParamenters<FileFilterModel> pagingParamenters)
            {
                if (pagingParamenters == null) return query;
                var searchText = pagingParamenters.Filter?.SearchText.Trim() ?? string.Empty;
                if(!string.IsNullOrEmpty(searchText)) {
                    query = query.Where(x => EF.Functions.Like(x.Title, $"%{searchText}%"));
                }
                return query;
            }

            public IQueryable<FileMedia> ApplyOrder(IQueryable<FileMedia> query, PagingOrderModel orderBy)
            {
                if(orderBy == null) return query;
                return base.ApplyOrder(query, orderBy, fieldName =>
                {
                    switch (fieldName)
                    {
                        case "CreateDate":
                            return entity => entity.CreateDate;
                        case "UpdateDate":
                            return entity => entity.UpdateDate;
                        case "Extension":
                            return entity => entity.Extension;
                        default:
                            return entity => entity.Title;
                    }
                });
            }
        }
    }
}
