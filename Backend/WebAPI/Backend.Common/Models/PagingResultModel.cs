using Backend.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models
{
    public class PagingResultModel<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalRecord { get; set; }

        public int TotalPage { get; set; }
        public PagingResultModel()
        {
            Data = new List<T>();
        }
    }

    public class PagingOrderModel
    {
        public OrderDirectionEnum Direction { get; set; }
        public string Name { get; set; }
    }

    public class PagingParamenters<TFilter>
    {
        public TFilter Filter { get; set;}
        public PagingOrderModel OrderBy { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
