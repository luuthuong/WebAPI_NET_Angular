using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class PaginationData<T>: List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public PaginationData( IEnumerable<T> source, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(source);
        }
        public static PaginationData<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginationData<T>(items,count, pageIndex, pageSize);
        }
    }
}
