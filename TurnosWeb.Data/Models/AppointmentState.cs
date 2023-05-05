using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosWeb.Data.Models
{
    [Table("AppointmentState")]
    public sealed class AppointmentState
    {
        [Key]
        public int AppointmentStateId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
