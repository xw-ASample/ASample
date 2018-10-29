using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASmaple.Domain.Models
{
    public class PagedData<T> where T:class
    {
        public PagedData(int pageIndex,int pageSize)
        {
            Current = pageIndex;
            RowCount = pageSize;
        }
        public int Current { get; set; }

        public int RowCount { get; set; }

        public int Total { get; set; }

        public List<T> Rows { get; set; }
    }
}
