using Microsoft.EntityFrameworkCore;
using Web_DemoWebAPIWithEFCore.Models;

namespace Web_DemoWebAPIWithEFCore.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
