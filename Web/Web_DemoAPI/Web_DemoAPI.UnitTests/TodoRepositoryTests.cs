using Web_DemoAPI.Models;
using Web_DemoAPI.Services;

namespace Web_DemoAPI.UnitTests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public async Task AddAsync_Should_Add_Todo()
        {
            var repo = new TodoRepository();
            var todoItem = "Test Todo";
            var todo = await repo.AddAsync(todoItem);

            Assert.Equal("Test Todo", todo.Title);
            Assert.False(todo.IsDone);
        }
    }
}