using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    public class AppointmentService
    {
        public int AppointmentServiceId { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public decimal AmountCharged { get; set; }
    }
}
