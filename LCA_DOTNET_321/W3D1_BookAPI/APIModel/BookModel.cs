using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.APIModel
{
    public class BookModel
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
       
        public string OriginalLanguage { get; set; }
       
        public string Genre { get; set; }
     
        public int PublicationYear { get; set; }
       
        public int AuthorId { get; set; }
        public string Author { get; set; } 
     
        public int PublisherId { get; set; }
        public string Publisher { get; set; }
        
    }
}
