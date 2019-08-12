using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Services
{
    public interface IPublisherServices
    {
        List<Publisher> GetAll();
        Publisher Get(int id);
        Publisher Add(Publisher newPublisher);
        Publisher Update(Publisher updatedPublisher);
        void Remove(Publisher removePublisher);

    }
}
