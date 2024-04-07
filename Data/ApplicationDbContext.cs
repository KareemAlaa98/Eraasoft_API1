using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments {get; set;}
        public ApplicationDbContext()
        {
           
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
    }
}
