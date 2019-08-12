using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace W3D1_BookAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FoundedYear { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
        [Required]
        public string HeadQuartersLocation { get; set; }
        public List<Book> Books { get; set; }
    }
}
