using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? Name { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Mail { get; set; }

    }
}
