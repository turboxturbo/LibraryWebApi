using Library.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Requests
{
    public class CreateUser
    {
        public string NameUser { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string Login {  get; set; }
        
    }
}
