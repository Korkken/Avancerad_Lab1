namespace Avancerad_Lab1.DTOs
{
    public class ReservationDTO
    {
        public DateTime BookingDate { get; set; }
        public int BookingDuration { get; set; }
        public int GuestAmount { get; set; }
        public int FK_SeatingId { get; set; }
        public int FK_CustomerId { get; set; }
    }
}
