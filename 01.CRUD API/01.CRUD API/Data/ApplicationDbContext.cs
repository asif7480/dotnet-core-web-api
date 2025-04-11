using _01.CRUD_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01.CRUD_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        
        }

        public DbSet<Order> Orders { get; set; }
    }
}
