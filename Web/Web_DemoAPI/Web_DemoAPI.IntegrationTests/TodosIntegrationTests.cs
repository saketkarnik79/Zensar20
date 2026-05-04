using System.Net.Http.Json;
using Web_DemoAPI.Models;

namespace Web_DemoAPI.IntegrationTests
{
    public class TodosIntegrationTests: IClassFixture<TodoApiFactory>
    {
       private readonly HttpClient _client;

        public TodosIntegrationTests(TodoApiFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Then_Get_Returns_Todo()
        {
            var response = await _client.PostAsJsonAsync("/api/todosapi", "Write integration tests");
            response.EnsureSuccessStatusCode();

           var getResponse = await _client.GetAsync("/api/todosapi");
            var todos = await getResponse.Content.ReadFromJsonAsync<List<TodoItem>>();
            Assert.Single(todos);
            Assert.Equal("Write integration tests", todos[0].Title);
        }
    }
}