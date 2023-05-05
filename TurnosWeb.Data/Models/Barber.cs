using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosWeb.Data.Models
{
    [Table("Barber")]
    public sealed class Barber
    {
        [Key]
        public int BarberId { get; set; }
        [Required]
        public string BarberName { get; set;}
        [Required]
        public bool IsActive { get; set; }
    }
}
