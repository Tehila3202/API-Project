using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? Name { get; set; }
    }
}
