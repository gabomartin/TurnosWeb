using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosWeb.Data.Models
{
    [Table("AppointmentService")]
    public sealed class AppointmentService
    {
        [Key]
        public int AppointmentServiceId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public decimal AmountCharged { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
