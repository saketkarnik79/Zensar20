using Microsoft.EntityFrameworkCore;
using Web_DemoWebAPIWithEFCore.Application.Repositories;
using Web_DemoWebAPIWithEFCore.Infrastructure.Data;

namespace Web_DemoWebAPIWithEFCore.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
