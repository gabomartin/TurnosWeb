
using TurnosWeb.Data.Models;

namespace TurnosWeb.Core.Dtos
{
    public class AppointmentDto
    {
        public int? BarberId { get; set; }
        public int? StateId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? ClientName { get; set; }
    }
}
