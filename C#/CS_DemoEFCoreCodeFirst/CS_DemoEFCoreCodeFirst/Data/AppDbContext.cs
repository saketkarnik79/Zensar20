using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS_DemoEFCoreCodeFirst.Models;

namespace CS_DemoEFCoreCodeFirst.Data
{
    internal class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreDemoDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
    }
}
