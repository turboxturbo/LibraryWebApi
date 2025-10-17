using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class HistoryRentBook
    {
        [Key]
        public int IdRent {  get; set; }
        public int Length { get; set; }// срок аренды

        [Required]
        [ForeignKey("reader")]
        public int IdReader { get; set; }
        public Reader reader { get; set; }
        [Required]
        [ForeignKey("book")]
        public int IdBook { get; set; }
        public Book book { get; set; }
    }
}
