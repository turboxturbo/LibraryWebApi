using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Requests
{
    public class CreateReader
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}