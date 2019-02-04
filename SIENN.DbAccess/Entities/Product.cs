using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SIENN.DbAccess.Entities
{
    public class Product : BaseEntity
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

        public long TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public ProductType ProductType { get; set; }

        public long UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; }

        public virtual ICollection<ProductCategories> ProductCategories { get; set; }
    }

    internal class PrloductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(p => p.Code).IsUnique();
        }
    }
}
