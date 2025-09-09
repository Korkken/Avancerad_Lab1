using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.Models
{
    public class Seating
    {
        [Key]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int TableNumber { get; set; }
        public bool IsBooked { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
    }
}
