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
        private readonly BookContext BookContext;

        //loosely tied constructor to db
        public AuthorServices(BookContext bookContext)
        {
            BookContext = bookContext;
        }
        // return whole context list
        public List<Author> GetAll()
        {
            return BookContext.Authors.ToList();
        }

        //return specific author from context list, if not found return null
        public Author GetId(int Id)
        {
            Author author = BookContext.Authors
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
            BookContext.Authors.Add(NewAuthor);
            BookContext.SaveChanges();
            return NewAuthor;

        }
        //update entry in db
        public Author Update(Author UpdatedAuthor)
        {
            // find if current entry is null and save its reference location
            var currentAuthor = BookContext.Authors.Find(UpdatedAuthor.Id);

            //return null if current is null
            if (currentAuthor == null)
            {
                return null;
            }

            //update entry's current values with new values from updatedbook
            BookContext.Entry(currentAuthor).CurrentValues.SetValues(UpdatedAuthor);

            BookContext.Authors.Update(currentAuthor);
            BookContext.SaveChanges();
            return currentAuthor;
        }
        public void Remove(Author DeleteAuthor)
        {
            BookContext.Authors.Remove(DeleteAuthor);
            BookContext.SaveChanges();
        }

    }
}
