using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Requests
{
    public class CreateGenres
    {
        public string Name { get; set; }
    }
}