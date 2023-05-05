using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosWeb.Data.Models
{
    [Table("Appointment")]
    public sealed class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int? BarberId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string ClientName { get; set; }
        public decimal? TotalCharged { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BarberId")]
        public Barber Barber { get; set; }

        [ForeignKey("StateId")]
        public AppointmentState State { get; set; }

        //[ForeignKey("AppointmentId")]
        public ICollection<AppointmentService>? AppointmentServices { get; set; }
    }
}
