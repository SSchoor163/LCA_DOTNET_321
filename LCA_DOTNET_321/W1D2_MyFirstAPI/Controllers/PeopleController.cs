using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        //set up some test data
        private static readonly List<Person> _people = new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Luke Skywalker",
                HairColor = "Blond"
            },
            new Person
            {
                Id = 5,
                Name = "Leia Organa",
                HairColor = "brown"
            }

        };
        // GET api/People
        [HttpGet]
        public IActionResult Get() //Return type is IActionResult
        {
            return Ok(_people); //return whole list of people
        }

        //GET api/people/5
        [HttpGet("{Id}")]
        [Produces("application/json")]
        public IActionResult Get(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            return Ok(person);
    }
        //[HttpGet("{Name}")]
        //[Produces("application/json")]
        //public IActionResult Get(string Name)
        //{
        //    var person = _people.FirstOrDefault(p => p.Name == Name);
        //    if (person == null) return NotFound();
        //    return Ok(person);
        //}

        // POST api/people
        [HttpPost]
        public IActionResult Post([FromBody] Person newPerson)
        {
            _people.Add(newPerson);
            return CreatedAtAction("Get", newPerson, new { id = new Random().Next() });
        }
        // ask jeffry about postman's id creation all being 0, despite a random generation being there.
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person newPerson)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
           
            person.Name = newPerson.Name;
            person.HairColor = newPerson.HairColor;
            return Ok(person);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            return Ok(person);

        }
    }
}
