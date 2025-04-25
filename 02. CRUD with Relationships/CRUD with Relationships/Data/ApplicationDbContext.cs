using CRUD_with_Relationships.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_with_Relationships.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId);
        }
    }
}
