using Microsoft.EntityFrameworkCore;
using AZ_DemoSQLAzure.Models;

namespace AZ_DemoSQLAzure.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
