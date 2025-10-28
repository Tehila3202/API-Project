using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class Maneger
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? Name { get; set; }
        [MinLength(2), MaxLength(300)]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

    }
}
