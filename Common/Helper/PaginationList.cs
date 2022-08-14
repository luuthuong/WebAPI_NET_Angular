using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class PaginationList<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        
        public static PaginationList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginationList<T>(items, count, pageIndex, pageSize);
        }

        public PaginationList(List<T> items, int count,int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage =(int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        
    }
}
