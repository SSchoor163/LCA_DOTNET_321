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
        IEnumerable<Book> GetAll();
        Book GetId(int Id);
        Book Add(Book NewBook);
        Book Update(Book UpdatedBook);
        void Remove(Book DeleteBook);

    }
}
