
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Core.Dtos
{
    public sealed class AppointmentViewDto
    {
        public int AppointmentId { get; set; }
        public string ClientName { get; set; }
        public string State { get; set; }
        public string BarberName { get; set; }

        public DateTime AppointmentDate { get; set; }
        public decimal? TotalCharged { get; set; }
        public IEnumerable<ServiceViewModel> Services { get; set; }

    }

    public sealed class ServiceViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
