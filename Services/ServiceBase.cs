using AutoMapper;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceBase
    {
        protected readonly AppDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public ServiceBase(AppDbContext dbContext, ILogger logger, IMapper mapper)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }

        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input)) return String.Empty;
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public IQueryable<T> ApplyOrder<T>(IQueryable<T> query)
        {

        }
    }
}
