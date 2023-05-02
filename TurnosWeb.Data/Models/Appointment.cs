using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    [Table("Appointment")]
    public class Appointment
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
        //[InverseProperty("Barber")]
        public Barber? Barber { get; set; }

        [ForeignKey("StateId")]
        //[InverseProperty("State")]
        public AppointmentState State { get; set; }

        //[ForeignKey("AppointmentId")]
        public List<AppointmentService>? Services { get; set; }
    }
}


/*	[AppointmentId] INT NOT NULL,
	[BarberId] INT NULL,
	[StateId] INT NOT NULL DEFAULT (1),
	[AppointmentDate] DATETIME NOT NULL,
	[ClientName] VARCHAR(50) NOT NULL,	
	[TotalCharged] MONEY NULL,
	[CreationDate] DATETIME NOT NULL,
	[ModifiedDate] DATETIME NOT NULL
*/