using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services.DTO
{
    public class PagingDto<T> where T : class
    {
        public IEnumerable<T> Results { get; set; }

        public long TotalRecords { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
