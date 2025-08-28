using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.DTOs
{
    public class CustomerDTO
    {
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public required string Phone { get; set; }
    }
}
