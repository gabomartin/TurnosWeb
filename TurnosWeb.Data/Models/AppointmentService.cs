using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    [Table("AppointmentService")]
    public class AppointmentService
    {
        [Key]
        public int AppointmentServiceId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public decimal AmountCharged { get; set; }

        
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        
    }
}
