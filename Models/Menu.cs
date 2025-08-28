using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MenuItem { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        public string? PictureUrl { get; set; }
    }
}
