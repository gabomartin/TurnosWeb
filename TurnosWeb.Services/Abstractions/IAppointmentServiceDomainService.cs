using TurnosWeb.Core.Dtos;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Abstractions
{
    public interface IAppointmentServiceDomainService
    {
        Task<IEnumerable<int>> CreateAppointmentServiceAsync(AppointmentServiceDto appointmentService, int appointmentId, CancellationToken cancellationToken);
        Task<int> DeleteAppointmentServiceByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<int>> DeleteAppointmentServicesByAppointmentIdAsync(int appointmentId, CancellationToken cancellationToken);
        IEnumerable<AppointmentService> GetAppointmentServicesByAppointmentId(int id);
    }
}