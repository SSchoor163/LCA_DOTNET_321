using System;
using System.Collections.Generic;
using W3D1_BookAPI.Data;
using W3D1_BookAPI.Models;
using System.Linq;
using System.Threading.Tasks;

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
        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books.ToList();
        }
        
        //return specific book from context list, if not found return null
        public Book GetId(int Id)
        {
            Book book = _bookContext.Books.Find(Id);
            if(book == null)
            {
                return null;
            }
            return book;
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
