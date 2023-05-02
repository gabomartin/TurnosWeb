using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosWeb.Data.Models
{
    [Table("Barber")]
    public class Barber
    {
        [Key]
        public int BarberId { get; set; }
        [Required]
        public string BarberName { get; set;}
        [Required]
        public bool IsActive { get; set; }
    }
}
