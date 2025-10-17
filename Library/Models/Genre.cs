using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Genre
    {
        [Key]
        public int IdGenre { get; set; }
        public string Name { get; set; }
    }
}
