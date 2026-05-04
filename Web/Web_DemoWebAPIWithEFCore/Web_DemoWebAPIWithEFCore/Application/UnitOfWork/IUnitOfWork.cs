using Web_DemoWebAPIWithEFCore.Application.Repositories;
using Web_DemoWebAPIWithEFCore.Models;

namespace Web_DemoWebAPIWithEFCore.Application.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Product> Products { get; }

        Task<int> CompleteAsync();
    }
}
