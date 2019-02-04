using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIENN.Services.DTO
{
    public class CategoryDto
    {
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
