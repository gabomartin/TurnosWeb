using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    public class Barber
    {
        public int BarberId { get; set; }
        public string BarberName { get; set;}
        public bool IsActive { get; set; }
    }
}
