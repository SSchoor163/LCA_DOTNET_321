using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author GetId(int Id);
        Author Add(Author NewAuthor);
        Author Update(Author UpdatedAuthor);
        void Remove(Author DeleteAuthor);
    }
}
