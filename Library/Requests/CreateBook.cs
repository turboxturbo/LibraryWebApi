using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Requests
{
    public class CreateBook
    {
        public string NameBook { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int IdGenre { get; set; } 
    }
}
