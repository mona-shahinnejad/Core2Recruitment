using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Entity.CreateDateTime = DateTime.Now;
                E.Entity.ModifyDateTime = DateTime.Now;
            });

            var ModifiedEntities = ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Modified).ToList();

            ModifiedEntities.ForEach(E =>
            {
                E.Entity.ModifyDateTime = DateTime.Now;
            });

            return base.SaveChanges();
        }
    }
}
