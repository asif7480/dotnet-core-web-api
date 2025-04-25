using CRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
