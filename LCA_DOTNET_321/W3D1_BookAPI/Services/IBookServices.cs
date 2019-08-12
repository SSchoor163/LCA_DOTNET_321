using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace W3D1_BookAPI.Services
{
    public interface IBookServices
    {
        List<Book> GetAll();
        Book GetId(int Id);
        List<Book> GetBooksForAuthor(int authorId);
        List<Book> GetBooksForPublisher(int publisherId);
        Book Add(Book NewBook);
        Book Update(Book UpdatedBook);
        void Remove(Book DeleteBook);

    }
}
