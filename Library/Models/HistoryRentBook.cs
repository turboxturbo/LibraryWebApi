using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Library.Models
{
    public class HistoryRentBook
    {
        [Key]
        public int IdRent {  get; set; }
        public DateTime DateStart { get; set; }// срок аренды
        public DateTime DateEnd { get; set; }// срок возврата
        public bool ReturnBook { get; set; } //вернул книгу

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
