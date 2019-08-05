using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Models;

namespace Students.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student newStudent);
        Student Update(Student updateStudent);
        void Remove(Student student);

    }
}
