using Microsoft.EntityFrameworkCore;
using ngfdfg.Models.Entities;

namespace ngfdfg.Data
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp>options):base(options) { 
        
        
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
