using System;
using System.Collections.Generic;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Services;
using W3D1_BookAPI.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices BookServices;
        public BookController(IBookServices bookServices)
        {
            BookServices = bookServices;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(BookServices.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = BookServices.GetId(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                BookServices.Add(book);
            }catch(System.Exception ex)
            {
                ModelState.AddModelError("addBook", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = book.Id }, book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            book.Id = id;
            var Book = BookServices.Update(book);
            if (Book == null) return NotFound();
            return Ok(Book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = BookServices.GetId(id);
            if (book == null) return NotFound();
            BookServices.Remove(book);
            return NoContent();
        }
    }
}
