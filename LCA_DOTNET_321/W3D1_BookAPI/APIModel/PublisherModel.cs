using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.APIModel
{
    public class PublisherModel
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
   
        public int FoundedYear { get; set; }
       
        public string CountryOfOrigin { get; set; }
  
        public string HeadQuartersLocation { get; set; }
        public List<Book> Books { get; set; }
    }
}

