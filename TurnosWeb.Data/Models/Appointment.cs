using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int? BarberId {get; set; }
		public int StateId { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string ClientName { get; set; }
		public decimal? TotalCharged { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime ModifiedDate { get; set;}
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