using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public required string Phone { get; set; }
        public int FK_BookingId { get; set; }

        public List<Reservation>? Bookings { get; set; }

    }
}
