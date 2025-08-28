using System.ComponentModel.DataAnnotations;

namespace Avancerad_Lab1.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
