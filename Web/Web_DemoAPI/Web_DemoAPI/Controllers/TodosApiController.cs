using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_DemoAPI.Repositories;

namespace Web_DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosApiController : ControllerBase
    {
        private readonly ITodoRepository _repo;

        public TodosApiController(ITodoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] string title)
        {
            var createdTodo = await _repo.AddAsync(title);
            return CreatedAtAction(nameof(GetTodos), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _repo.GetAllAsync();
            return Ok(todos);
        }
    }
}