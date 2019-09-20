using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using W3D1_BookAPI.APIModel;

using W3D1_BookAPI.Services;

namespace W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        private readonly IPublisherServices PublisherServices;
        public PublishersController(IPublisherServices publisherServices)
        {
            PublisherServices = publisherServices;
        }

        // GET: api/Publishers
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(PublisherServices.GetAll().ToApiModels());
        }

        // GET: api/Publishers/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var publisher = PublisherServices.Get(id).ToApiModel();
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // POST: api/Publishers
        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)
        {
            try
            { 
            PublisherServices.Add(newPublisher.ToDomainModel());
            }
            catch(System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatedPublisher)
        {
            updatedPublisher.Id = id;
            var publisher = PublisherServices.Update(updatedPublisher.ToDomainModel());
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Publisher = PublisherServices.Get(id);
            if (Publisher == null) return NotFound();
            PublisherServices.Remove(Publisher);
            return NoContent();
        }
    }
}
