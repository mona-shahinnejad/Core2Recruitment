using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIENN.Services.DTO
{
    public class ProductTypeDto
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
