using TurnosWeb.Data.Dtos;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Services.Interfaces
{
    public interface IAppointmentServiceDataSvc
    {
        Task<IEnumerable<int>> CreateAppointmentServiceAsync(AppointmentServiceDto appointmentService, int appointmentId, CancellationToken cancellationToken);
        Task<int> DeleteAppointmentServiceByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<int>> DeleteAppointmentServicesByAppointmentIdAsync(int appointmentId, CancellationToken cancellationToken);
        IEnumerable<AppointmentService> GetAppointmentServicesByAppointmentId(int id);
    }
}