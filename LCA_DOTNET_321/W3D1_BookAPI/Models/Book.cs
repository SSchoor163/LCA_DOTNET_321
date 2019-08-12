using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W3D1_BookAPI.Models
{
    public class Book
    {
       public int Id { get; set; }
        [Required]
       public string Title { get; set; }
        [Required]
        public string OriginalLanguage { get; set; }
       [Required]
        public string Genre { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
       public int AuthorId { get; set; }
       public Author Author { get; set; } //navigation property
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } //navigation Property
    }
}
