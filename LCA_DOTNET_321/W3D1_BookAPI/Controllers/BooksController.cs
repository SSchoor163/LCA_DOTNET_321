using System;
using System.Collections.Generic;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Services;
using W3D1_BookAPI.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W3D1_BookAPI.APIModel;

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
            var books = BookServices.GetAll().ToApiModels();
            return Ok(books);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = BookServices.GetId(id).ToApiModel();
            if (book == null) return NotFound();
            return Ok(book);
        }

        //Get api/author/{authorId}/books
        [HttpGet("/api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookServices = BookServices.GetBooksForAuthor(authorId).ToApiModels();
            return Ok(BookServices);
        }

        //Get api/publisher/{publisherId}/books
        [HttpGet("/api/publisher/{publisherId}/books")]
        public IActionResult GetBooksForPublisher(int publisherId)
        {
            var bookServices = BookServices.GetBooksForPublisher(publisherId).ToApiModels();
            return Ok(bookServices);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] BookModel bookModel)
        {
            try
            {
                BookServices.Add(bookModel.ToDomainModel());
            }catch(System.Exception ex)
            {
                ModelState.AddModelError("addBook", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = bookModel.Id }, bookModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookModel bookModel)
        {
            bookModel.Id = id;
            var Book = BookServices.Update(bookModel.ToDomainModel());
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
