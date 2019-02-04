using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SIENN.Services.DTO
{
    public class ProductDto
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime DeliveryDateTime { get; set; }

        public string TypeCode { get; set; }

        public string UnitCode { get; set; }

        public string[] Categories { get; set; }
    }
}
