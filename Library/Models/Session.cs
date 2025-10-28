using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Session
    {
        [Key]
        public int Idsession { get; set; }
        public string Token { get; set; }
        [Required]
        [ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
