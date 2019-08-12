using System;
using System.Collections.Generic;
using W3D1_BookAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace W3D1_BookAPI.APIModel
{
    public class AuthorModel
    {

        public int Id { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
      
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; }

    }
}
