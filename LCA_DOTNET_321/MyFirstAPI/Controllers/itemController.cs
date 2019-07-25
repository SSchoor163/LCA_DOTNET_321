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
    public class ItemController : ControllerBase
    {

        //set up some test data
        private static readonly List<Item> _Item = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Light Saber",
                Description = "A weapon for a more civilized age"
            },
            new Item
            {
                Id = 3,
                Name = "Bacta Tank",
                
                Description = "Healing Pod"
            }

        };
        // GET api/Item
        [HttpGet]
        public IActionResult Get() //Return type is IActionResult
        {
            return Ok(_Item); //return whole list of people
        }

        //GET api/people/5
        [HttpGet("{Id}")]
        [Produces("application/json")]
        public IActionResult Get(int id)
        {
            var item = _Item.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
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
        public IActionResult Post([FromBody] Item newItem)
        {
            _Item.Add(newItem);
            return CreatedAtAction("Get", newItem, new { id = new Random().Next() });
        }
        // ask jeffry about postman's id creation all being 0, despite a random generation being there.
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
