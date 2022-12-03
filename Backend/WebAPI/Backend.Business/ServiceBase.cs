using AutoMapper;
using Backend.Common.Enums;
using Backend.Common.Models;
using Backend.DBContext;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Backend.Business
{
    public class ServiceBase
    {
        protected readonly AppDbContext DBContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public ServiceBase(AppDbContext dBContext, ILogger logger, IMapper mapper)
        {
            DBContext = dBContext;
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
}