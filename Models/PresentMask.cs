using System.ComponentModel.DataAnnotations;

namespace chineseAction.Models
{
    public class PresentMask
    {
        public int Id { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public int? Price { get; set; }
        public string? Donater { get; set; }
        public int? NumBuyers { get; set; }
    }
}
