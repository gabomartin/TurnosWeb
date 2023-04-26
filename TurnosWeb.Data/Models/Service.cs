using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public decimal Cost {get; set; }
        public bool IsActive { get; set; }
    }
}
