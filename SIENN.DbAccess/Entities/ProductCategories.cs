using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIENN.DbAccess.Entities
{
    public class ProductCategories
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }

    internal class ProductCategoriesConfigurations : IEntityTypeConfiguration<ProductCategories>
    {
        public void Configure(EntityTypeBuilder<ProductCategories> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            builder
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);
        }
    }
}