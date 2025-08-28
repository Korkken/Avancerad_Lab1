using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingDuration { get; set; }
        public int GuestAmount { get; set; }
        public int FK_SeatingId { get; set; }
        public int FK_CustomerId { get; set; }
        public List<Seating>? Seatings { get; set; }
    }
}
