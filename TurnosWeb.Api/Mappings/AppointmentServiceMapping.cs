using TurnosWeb.Core.Dtos;
using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Api.Mappings
{
    public static class AppointmentServiceMapping
    {
        public static void MapAppointmentServiceEndpoints(this WebApplication app)
        {
            app.MapPost("/AppointmentService/{appointmentId}", async (IAppointmentServiceDomainService contextService, int appointmentId, HttpRequest req, CancellationToken cancellationToken) =>
            {
                var appointment = await req.ReadFromJsonAsync<AppointmentServiceDto>();
                return new { Id = await contextService.CreateAppointmentServiceAsync(appointment, appointmentId, cancellationToken) };
            })
            .WithName("PostAppointmentService")
            .WithOpenApi();

            app.MapDelete("Appointment/AppointmentService/{appointmentId}", async (IAppointmentServiceDomainService contextService, int appointmentId, CancellationToken cancellationToken) =>
            {
                return new { AppointmentServiceIds = await contextService.DeleteAppointmentServicesByAppointmentIdAsync(appointmentId, cancellationToken) };
            })
            .WithName("DeleteAppointmentServices")
            .WithOpenApi();

            app.MapDelete("/AppointmentService/{appointmentServiceId}", async (IAppointmentServiceDomainService contextService, int appointmentServiceId, CancellationToken cancellationToken) =>
            {
                return new { AppointmentServiceId = await contextService.DeleteAppointmentServiceByIdAsync(appointmentServiceId, cancellationToken) };
            })
            .WithName("DeleteAppointmentService")
            .WithOpenApi();
        }
    }
}
