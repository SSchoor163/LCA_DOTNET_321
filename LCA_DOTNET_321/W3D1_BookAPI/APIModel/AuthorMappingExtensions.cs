using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.APIModel
{
    public static class AuthorMappingExtensions
    {
        public static AuthorModel ToApiModel( this Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                BirthDate = author.BirthDate,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

        }
        public static Author ToDomainModel(this AuthorModel authorModel)
        {
            return new Author
            {
                Id = authorModel.Id,
                BirthDate = authorModel.BirthDate,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
        }

        public static List<AuthorModel> ToApiModels (this List<Author> authors)
        {
            return authors.Select(a => a.ToApiModel()).ToList();
        }

        public static List<Author> ToDomainModels (this List<AuthorModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel()).ToList();
        }



    }
}
