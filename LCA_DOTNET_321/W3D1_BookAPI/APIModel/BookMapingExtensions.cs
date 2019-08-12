using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.APIModel
{
    public static class BookMapingExtensions
    {
        public static BookModel ToApiModel (this Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Genre = book.Genre,
                OriginalLanguage = book.OriginalLanguage,
                PublicationYear = book.PublicationYear,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Author = $"{book.Author.LastName} , {book.Author.FirstName}",
                PublisherId = book.PublisherId,
                Publisher = $"{book.Publisher.Name}, {book.Publisher.HeadQuartersLocation}"
            };
        }

        public static Book ToDomainModel (this BookModel bookModel)
        {
            return new Book
            {
                Id = bookModel.Id,
                Genre = bookModel.Genre,
                OriginalLanguage = bookModel.OriginalLanguage,
                PublicationYear = bookModel.PublicationYear,
                Title = bookModel.Title,
                AuthorId = bookModel.AuthorId,
                PublisherId = bookModel.PublisherId
            };
        }

        public static List<BookModel> ToApiModels (this List<Book> books)
        {
            return books.Select(b => b.ToApiModel()).ToList();
        }

        public static List<Book> ToDomainModels (this List<BookModel> bookModels)
        {
            return bookModels.Select(b => b.ToDomainModel()).ToList();
        }
    }
}
