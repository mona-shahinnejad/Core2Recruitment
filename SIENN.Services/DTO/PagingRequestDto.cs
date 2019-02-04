using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services.DTO
{
    public class PagingRequestDto
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
