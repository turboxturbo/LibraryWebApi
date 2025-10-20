using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Requests
{
    public class CreateRent
    {
        public DateTime DateStart { get; set; }// срок аренды
        public DateTime DateEnd { get; set; }// срок возврата
        public int IdReader { get; set; }
        public int IdBook { get; set; }
        
    }
}