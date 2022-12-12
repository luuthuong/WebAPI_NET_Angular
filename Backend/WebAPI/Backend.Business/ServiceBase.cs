using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Backend.Business
{
    public class ServiceBase
    {
        protected readonly AppDbContext DBContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public ServiceBase(AppDbContext dbContext, ILogger logger, IMapper mapper)
        {
            DBContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
        public string FirstCharToUpper(string input)
        {
            return String.IsNullOrEmpty(input) ? String.Empty : input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public IQueryable<T> ApplyOrder<T>(IQueryable<T> query, PagingOrderModel orderBy, Func<string, Expression<Func<T,object>>> orderFieldFunc)
        {
            var orderByName = FirstCharToUpper(orderBy.Name) ?? string.Empty;
            var orderByDirection = orderBy?.Direction ?? OrderDirectionEnum.ASC;
            var orderExpression = orderFieldFunc(orderByName);
            if(orderByDirection == OrderDirectionEnum.DESC)
            {
                return query.OrderByDescending(orderExpression);
            }
            return query.OrderBy(orderExpression);
        }
    }

    public static class PaginationList
    {
        public static async Task<PagingResultModel<T>> CreatePagingResultAsync<T, TFilter>(this IQueryable<T> source, PagingParamenters<TFilter> pagingFilter)
        {
            var result =await source.ToListAsync();
            var pagingResult = new PagingResultModel<T>();
            pagingResult.TotalRecord = result.Count;
            pagingResult.TotalPage = (int)Math.Ceiling(pagingResult.TotalRecord / (double)pagingFilter.PageSize);
            pagingResult.Data = result.Skip((pagingFilter.PageIndex - 1) * pagingFilter.PageSize).Take(pagingFilter.PageSize);
            return pagingResult;
        }

        public static PagingResultModel<TDest> MapPagingResult<TEntity,TDest>(this IMapper mapper, PagingResultModel<TEntity> source)
        {
            return new PagingResultModel<TDest>()
            {
                Data = mapper.Map<List<TEntity>, List<TDest>>(source.Data.ToList()),
                TotalPage = source.TotalPage, 
                TotalRecord = source.TotalRecord,
            };
        }
    }
}