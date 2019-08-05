using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Models;

namespace Students.Services
{
    public class StudentServices: IStudentsService
    {
       private List<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                FirstName = "Steven",
                LastName = "Schoor",
                BirthDate = new DateTime(2010, 1, 1),
                Email = "Steven_schoor@gmail.com",
                Phone = "806.218.4181"
            },
            new Student
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2010, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"
            }
        };
        private int nextId = 3;

       public IEnumerable<Student> GetAll()
        {
            return students;
        }
       public Student Get(int id)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return null;
            return student;
        }
       public Student Add(Student newStudent)
        {
            ValidateBirthDate(newStudent);
            newStudent.Id = nextId++;
            students.Add(newStudent);
            return newStudent;
        }
        public Student Update(Student updateStudent)
        {
            ValidateBirthDate(updateStudent);
            Student student = students.FirstOrDefault(s => s.Id == updateStudent.Id);
            if (student == null)
                return null;
            student.FirstName = updateStudent.FirstName;
            student.LastName = updateStudent.LastName;
            student.BirthDate = updateStudent.BirthDate;
            student.Email = updateStudent.Email;
            student.Phone = updateStudent.Phone;
            return student;
        }
       public void Remove(Student student)
        {
            students.Remove(student);
        }

        public void ValidateBirthDate( Student student)
        {
            if (student.BirthDate > DateTime.Now)
                throw new ApplicationException("Birthdate Can not be in the future");
            if (DateTime.Today.Year - student.BirthDate.Year > 18)
                throw new ApplicationException("This Person is too old to be a student");

        }
    }
}
