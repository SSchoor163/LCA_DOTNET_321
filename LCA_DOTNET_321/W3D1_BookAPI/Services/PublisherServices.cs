using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;
using W3D1_BookAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace W3D1_BookAPI.Services
{
    public class PublisherServices:IPublisherServices
    {
        private readonly BookContext BookContext;
        
        PublisherServices(BookContext bookContext)
        {
            BookContext = bookContext;
        }
       public List<Publisher> GetAll()
        {
            return BookContext.Publishers.ToList();
        }
        public Publisher Get(int id)
        {
            Publisher publisher = BookContext.Publishers
                .Include(p=>p.Books)
                .FirstOrDefault(p => p.Id == id);
            if (publisher == null) return null;
            return publisher;
        }
        public Publisher Add(Publisher newPublisher)
        {
            BookContext.Publishers.Add(newPublisher);
            BookContext.SaveChanges();
            return newPublisher;
        }
       public Publisher Update(Publisher updatedPublisher)
        {
            var CurrentPublisher = BookContext.Publishers.FirstOrDefault(p => p.Id == updatedPublisher.Id);
            if (CurrentPublisher == null) return null;
            BookContext.Entry(CurrentPublisher).CurrentValues.SetValues(updatedPublisher);
            BookContext.Update(CurrentPublisher);
            BookContext.SaveChanges();
            return CurrentPublisher;
        }
        public void Remove(Publisher removePublisher)
        {
            BookContext.Publishers.Remove(removePublisher);
            BookContext.SaveChanges();
        }
    }
}
