using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chineseAction.Models
{
    public class Present
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(300)]
        public string? Title { get; set; }

        [MinLength(2), MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public  int? CategoryId{ get; set; }
        public string? Image { get; set; }
        public int? Price { get; set; }

        [Required]
        public  int? DonaterId { get; set; }
 
        public int? NumBuyers { get; set; }

        [ForeignKey("CateroryId")]
        public virtual Category? Caterory { get; set; }

        [ForeignKey("DonaterId")]
        public virtual Donater? Donater { get; set; }

    }
}
