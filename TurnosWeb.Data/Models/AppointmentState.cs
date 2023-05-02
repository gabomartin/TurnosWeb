using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    [Table("AppointmentState")]
    public class AppointmentState
    {
        [Key]
        public int AppointmentStateId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
