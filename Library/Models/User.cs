using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Library.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string Description {  get; set; }
        public Role role { get; set; }
        [Required]
        [ForeignKey("role")]
        public int IdRole { get; set; }
    }
}
