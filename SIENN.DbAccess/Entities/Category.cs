using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIENN.DbAccess.Entities
{
    public class Category : BaseEntity
    {
        [MaxLength(20)]
        [Required]
        public string Code { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
    }

    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new Category { Id = 1, Code = "C0001", Name = "House Stuff" },
                new Category { Id = 2, Code = "C0002", Name = "Kitchen Stuff" },
                new Category { Id = 3, Code = "C0003", Name = "Electronic & Computer" },
                new Category { Id = 4, Code = "C0004", Name = "Personal Stuff" }
                );
        }
    }
}
