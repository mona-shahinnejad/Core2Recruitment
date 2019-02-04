using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.Services.DTO
{
    public class ProductCustomViewDto
    {
        public string ProductDescription { get; set; }

        public string Price { get; set; }

        public string IsAVailable { get; set; }

        public string DeliveryDate { get; set; }

        public int CategoryCount { get; set; }

        public string Type { get; set; }

        public string Unit { get; set; }
    }
}
