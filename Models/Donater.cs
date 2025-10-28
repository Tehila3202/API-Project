using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace chineseAction.Models
{
    public class Donater
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? Name { get; set; }
        public string? Phone { get; set; }

        [EmailAddress]
        public string Mail { get; set; }


    }
}
