using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIENN.DbAccess.Entities
{
    public class Unit : BaseEntity
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

    internal class UnitConfigurations : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasIndex(u => u.Code).IsUnique();
            builder.HasIndex(u => u.Acronym).IsUnique();

            builder.HasData(
                new Unit { Id = 1, Code = "U0001", Name = "Piece", Acronym = "pc", Description = "Normal piece of products" },
                new Unit { Id = 2, Code = "U0002", Name = "Box", Acronym = "b", Description = "Normal box of products,contains 6 pieces" },
                new Unit { Id = 3, Code = "U0003", Name = "Meter", Acronym = "m", Description = "Meter" }
                );
        }
    }
}
