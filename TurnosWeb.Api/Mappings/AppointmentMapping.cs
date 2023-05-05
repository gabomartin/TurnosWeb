using TurnosWeb.Core.Dtos;
using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Api.Mappings
{
    public static class AppointmentMapping
    {
        public static void MapAppointmentEndpoints(this WebApplication app)
        {
            app.MapPost("/Appointment", async (IAppointmentDomainService contextService, HttpRequest req, CancellationToken cancellationToken) =>
            {
                var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
                return new { Id = await contextService.CreateAppointmentAsync(appointment, cancellationToken) };
            })
            .WithName("PostAppointment")
            .WithOpenApi();

            app.MapGet("/Appointment/{id}", async (IAppointmentDomainService contextService, int id, CancellationToken cancellationToken) =>
            {
                return await contextService.GetAppointmentByIdAsync(id, cancellationToken);
            })
            .WithName("GetAppointment")
            .WithOpenApi();

            app.MapGet("/Appointments", async (IAppointmentDomainService contextService, CancellationToken cancellationToken) =>
            {
                var data = await contextService.GetAppointmentsViewModel(cancellationToken);
                return data;
            })
            .WithName("GetAppointments")
            .WithOpenApi();

            app.MapPut("/Appointment/{id}", async (IAppointmentDomainService contextService, int id, HttpRequest req, CancellationToken cancellationToken) =>
            {
                var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
                return new { Id = await contextService.UpdateAppointmentAsync(appointment, id, cancellationToken) };
            })
            .WithName("UpdateAppointment")
            .WithOpenApi();
        }
    }
}
