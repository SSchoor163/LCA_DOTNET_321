using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using W3D1_BookAPI.Data;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Services;

namespace W3D1_BookAPI.Controllers
{[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService AuthorServices;
    public AuthorController(IAuthorService authorServices)
    {
        AuthorServices = authorServices;
    }
    // GET api/values
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(AuthorServices.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var author = AuthorServices.GetId(id);
        if (author == null) return NotFound();
        return Ok(author);
    }

    // POST api/values
    [HttpPost]
    public ActionResult Post([FromBody] Author author)
    {
        try
        {
            AuthorServices.Add(author);
        }
        catch (System.Exception ex)
        {
            ModelState.AddModelError("addAuthor", ex.Message);
            return BadRequest(ModelState);
        }
        return CreatedAtAction("Get", new { Id = author.Id }, author);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Author author)
    {
        author.Id = id;
        var Author = AuthorServices.Update(author);
        if (Author == null) return NotFound();
        return Ok(Author);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var author = AuthorServices.GetId(id);
        if (author == null) return NotFound();
        AuthorServices.Remove(author);
        return NoContent();
    }
}
}