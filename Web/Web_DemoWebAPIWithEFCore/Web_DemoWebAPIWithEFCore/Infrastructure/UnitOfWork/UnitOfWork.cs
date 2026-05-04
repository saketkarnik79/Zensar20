using Web_DemoWebAPIWithEFCore.Application.Repositories;
using Web_DemoWebAPIWithEFCore.Infrastructure.Data;
using Web_DemoWebAPIWithEFCore.Application.UnitOfWork;
using Web_DemoWebAPIWithEFCore.Models;

namespace Web_DemoWebAPIWithEFCore.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public IGenericRepository<Product> Products { get; }

        public UnitOfWork(AppDbContext context, IGenericRepository<Product> products)
        {
            _context = context;
            Products = products;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
