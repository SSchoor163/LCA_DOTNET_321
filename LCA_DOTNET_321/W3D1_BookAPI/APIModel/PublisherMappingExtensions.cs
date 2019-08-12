using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.APIModel
{
    public static class PublisherMappingExtensions
    {

        public static PublisherModel ToApiModel(this Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                FoundedYear = publisher.FoundedYear,
                HeadQuartersLocation = publisher.HeadQuartersLocation,
                CountryOfOrigin = publisher.CountryOfOrigin,
            };
        }

        public static Publisher ToDomainModel(this PublisherModel publisherModel)
        {
            return new Publisher
            {
                Id = publisherModel.Id,
                Name = publisherModel.Name,
                FoundedYear = publisherModel.FoundedYear,
                HeadQuartersLocation = publisherModel.HeadQuartersLocation,
                CountryOfOrigin = publisherModel.CountryOfOrigin,
            };
        }

        public static List<PublisherModel> ToApiModels (this List<Publisher> publishers)
        {
            return publishers.Select(p => p.ToApiModel()).ToList();
        }

        public static List<Publisher> ToDomainModels (this List<PublisherModel> publisherModels)
        {
            return publisherModels.Select(p => p.ToDomainModel()).ToList();
        }
    }
}
