using Web_DemoAPI.Models;
using Web_DemoAPI.Repositories;

namespace Web_DemoAPI.Services
{
    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _items = new();
        private int _id = 1;

        public Task<TodoItem> AddAsync(string title)
        {
            var item = new TodoItem(_id++, title, false);
            _items.Add(item);
            return Task.FromResult(item);
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync() => Task.FromResult(_items.AsEnumerable());
    }
}
