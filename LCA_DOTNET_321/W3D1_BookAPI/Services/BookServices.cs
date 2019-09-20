using System;
using System.Collections.Generic;
using W3D1_BookAPI.Data;
using W3D1_BookAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace W3D1_BookAPI.Services
{
    public class BookServices : IBookServices
    {
        //Database initialization
        private readonly BookContext _bookContext;

        //loosely tied constructor to db
        public BookServices(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
       // return whole context list
        public List<Book> GetAll()
        {
            return _bookContext.Books.
                Include(b=>b.Author).
                Include(b=>b.Publisher)
                .ToList();
        }
        
        //return specific book from context list, if not found return null
        public Book GetId(int Id)
        {
            Book book = _bookContext.Books
                .Include(x=>x.Author)
                .Include(x=>x.Publisher)
                .FirstOrDefault(x=>x.Id == Id);
            if(book == null)
            {
                return null;
            }
            return book;
        }

        //return list of books for a Author
        public List<Book> GetBooksForAuthor(int authorId)
        {
            var books = _bookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.AuthorId == authorId)
                .ToList();
            return books;
        }

        //Return list of books for a publisher
        public List<Book> GetBooksForPublisher(int publisherId)
        {
            return _bookContext.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.PublisherId == publisherId)
                .ToList();
        }

        //set newbook id to next valid id. add newbook to context list. save database context, return newbook
        public Book Add(Book NewBook)
        {
            _bookContext.Books.Add(NewBook);
            _bookContext.SaveChanges();
            return NewBook;

        }
        //update entry in db
        public Book Update(Book UpdatedBook)
        {
            // find if current entry is null and save its reference location
            var currentBook = _bookContext.Books.Find(UpdatedBook.Id);

            //return null if current is null
            if(currentBook == null)
            {
                return null;
            }

            //update entry's current values with new values from updatedbook
            _bookContext.Entry(currentBook).CurrentValues.SetValues(UpdatedBook);
           
            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }
        public void Remove(Book DeleteBook)
        {
            _bookContext.Books.Remove(DeleteBook);
            _bookContext.SaveChanges();
        }

    }
}
