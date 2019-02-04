using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIENN.DbAccess.Entities
{
    public class ProductType : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }

    internal class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasIndex(pt => pt.Code).IsUnique();

            builder.HasData(
                new ProductType { Id = 1, Code = "PT0001", Name = "Cooking Stuff" },
                new ProductType { Id = 2, Code = "PT0002", Name = "Sleeping Stuff" },
                new ProductType { Id = 3, Code = "PT0003", Name = "Car Accessories" },
                new ProductType { Id = 4, Code = "PT0004", Name = "Mobile" },
                new ProductType { Id = 5, Code = "PT0005", Name = "Watche" }
                );
        }
    }
}
