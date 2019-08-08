using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace W3D1_BookAPI.Services
{
    public class AuthorServices :IAuthorService
    {
        //Database initialization
        private readonly BookContext _bookContext;

        //loosely tied constructor to db
        public AuthorServices(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        // return whole context list
        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors.ToList();
        }

        //return specific book from context list, if not found return null
        public Author GetId(int Id)
        {
            Author author = _bookContext.Authors
                .Include(p=>p.Books)
                .FirstOrDefault(p=>p.Id==Id);
            if (author == null)
            {
                return null;
            }
            return author;
        }
        //set newbook id to next valid id. add newbook to context list. save database context, return newbook
        public Author Add(Author NewAuthor)
        {
            _bookContext.Authors.Add(NewAuthor);
            _bookContext.SaveChanges();
            return NewAuthor;

        }
        //update entry in db
        public Author Update(Author UpdatedAuthor)
        {
            // find if current entry is null and save its reference location
            var currentAuthor = _bookContext.Authors.Find(UpdatedAuthor.Id);

            //return null if current is null
            if (currentAuthor == null)
            {
                return null;
            }

            //update entry's current values with new values from updatedbook
            _bookContext.Entry(currentAuthor).CurrentValues.SetValues(UpdatedAuthor);

            _bookContext.Authors.Update(currentAuthor);
            _bookContext.SaveChanges();
            return currentAuthor;
        }
        public void Remove(Author DeleteAuthor)
        {
            _bookContext.Authors.Remove(DeleteAuthor);
            _bookContext.SaveChanges();
        }

    }
}
