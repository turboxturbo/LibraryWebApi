using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Requests
{
    public class CreateRent
    {
        public DateTime DateStart { get; set; }// срок аренды
        public bool ReturnBook { get; set; } //вернул книгу
        public DateTime DateEnd { get; set; }// дата возврата
        public int IdReader { get; set; }
        public int IdBook { get; set; }
        
    }
}