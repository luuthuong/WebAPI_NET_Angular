using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class PagingModel<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }

        public PagingModel()
        {
            Data = new List<T>();
        }
    }

    public class PaginOrderModel { 
        public string Name { get; set; }
        public OrderDirectionEnum Direction { get; set; }
        public PaginOrderModel()
        {
            Name = string.Empty;
        }
    }

    public class PagingParameters<TFilter>
    {
        public TFilter? Filter { get; set; }
        public PaginOrderModel? OrderBy { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

}
