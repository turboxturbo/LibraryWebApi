using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }

        [Required]
        [ForeignKey("Genre")]
        public int IdGenre { get; set; }
        public Genre Genre { get; set; }
        
    }
}
