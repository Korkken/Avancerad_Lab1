using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.DTOs
{
    public class MenuDTO
    {
        public string MenuItem { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        public string? PictureUrl { get; set; }
    }
}
