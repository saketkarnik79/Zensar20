using Microsoft.AspNetCore.Mvc;
using Web_DemoControllerWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_DemoControllerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleApiController : ControllerBase
    {
        static List<Person> _people;

        static PeopleApiController()
        {
            _people = new List<Person>()
            {
                new Person() { Id = 1, Name = "Alice", Age = 30 },
                new Person() { Id = 2, Name = "Bob", Age = 25 },
                new Person() { Id = 3, Name = "Charlie", Age = 35 },
                new Person() { Id = 4, Name = "Diana", Age = 28 },
                new Person() { Id = 5, Name = "Ethan", Age = 32 }
            };
        }

        // GET: api/<PeopleApiController>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_people);
        }

        // GET api/<PeopleApiController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST api/<PeopleApiController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([Bind("Name,Age")][FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = _people.Max(p => p.Id) + 1; // Auto-increment Id
                _people.Add(person);
                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<PeopleApiController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest("Id didn't match.");
            }
            if (ModelState.IsValid)
            {
                var existingPerson = _people.FirstOrDefault(p => p.Id == id);
                if (existingPerson == null)
                {
                    return NotFound();
                }
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<PeopleApiController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _people.Remove(person);
                return NoContent();
            }
            return NotFound();
        }
    }
}
