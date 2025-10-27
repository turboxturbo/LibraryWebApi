using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Login
    {
        [Key]
        public int Idlogin { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        [Required]
        [ForeignKey("user")]
        public int IdUser { get; set; }
        public User user { get; set; }
    }
}
