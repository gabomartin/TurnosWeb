using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosWeb.Data.Models
{
    [Table("Service")]
    public sealed class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Cost {get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
