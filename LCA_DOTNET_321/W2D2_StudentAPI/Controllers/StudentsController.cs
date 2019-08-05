using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Models;
using Students.Services;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
      private readonly  IStudentsService StudentService;
        public StudentsController(IStudentsService studentsService) {
            StudentService = studentsService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(StudentService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = StudentService.Get(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student newStudent)
        {
            try
            {
                StudentService.Add(newStudent);
            }catch(System.Exception ex)
            {
                ModelState.AddModelError("AddStudent", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newStudent.Id }, newStudent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updateStudent)
        {
            updateStudent.Id = id;
            var student = StudentService.Update(updateStudent);
            if(student == null)
                return NotFound();
            return Ok(student);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = StudentService.Get(id);
            if (student == null)
                return NotFound();
            StudentService.Remove(student);
            return NoContent();
        }
    }
}
