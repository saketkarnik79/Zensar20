using Microsoft.AspNetCore.Mvc;
using Web_DemoMVCApp.Models;

namespace Web_DemoMVCApp.Controllers
{
    public class PeopleController : Controller
    {
        private static List<Person> people = new List<Person>() 
        {
            new Person() { Id = 1, Name = "John Doe", Age = 30 },
            new Person() { Id = 2, Name = "Jane Smith", Age = 25 },
            new Person () { Id = 3, Name = "Alice Johnson", Age = 28 },
            new Person() { Id = 4, Name = "Bob Brown", Age = 35 },
            new Person() { Id = 5, Name = "Charlie Davis", Age = 22 }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(people);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name,Age")] [FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = people.Max(p => p.Id) + 1;
                people.Add(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = people.FirstOrDefault(p => p.Id == person.Id);
                if (existingPerson == null)
                {
                    return NotFound();
                }
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        { 
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            people.Remove(person);
            return RedirectToAction(nameof(Index));
        }
    }
}