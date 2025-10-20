using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Reader
    {
        [Key]
        public int IdReader { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
