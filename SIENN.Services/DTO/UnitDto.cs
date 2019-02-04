using System.ComponentModel.DataAnnotations;

namespace SIENN.Services.DTO
{
    public class UnitDto
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(5)]
        public string Acronym { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
