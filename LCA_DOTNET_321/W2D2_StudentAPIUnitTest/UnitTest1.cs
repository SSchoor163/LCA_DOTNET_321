using System;
using Xunit;
using Students.Controllers;
using Students.Models;
using Students.Services;
using Microsoft.AspNetCore.Mvc;

namespace StudenteUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Post_ShouldReturnBadRequestIfBirthdateIsInFuture()
        {
            Student student = new Student()
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2999, 1, 1), // in the future
                Email = "test@test.com",
                Phone = "555-555-5555"
            };
            var result = TryPost(student);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void Post_ShouldReturnBadRequestIfBirthdateIsTooOld()
        {
           
            Student student = new Student()
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2015, 1, 1), // in the future
                Email = "test@test.com",
                Phone = "555-555-5555"
            };
            var result = TryPost(student);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        public IActionResult TryPost(Student student)
        {
            StudentsController controller = new StudentsController(new StudentServices());
            var result = controller.Post(student);
            return result;
        }
    }
}
