using Web_DemoAPI.Models;

namespace Web_DemoAPI.Repositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> AddAsync(string title);
        Task<IEnumerable<TodoItem>> GetAllAsync();
    }
}
