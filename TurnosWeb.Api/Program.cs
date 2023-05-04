using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Core.Dtos;
using TurnosWeb.Services.Interfaces;
using TurnosWeb.Services.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationManager().AddJsonFile("appSettings.json").Build();

builder.Services.AddDbContext<TurnosWebContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.Add(new ServiceDescriptor(typeof(IAppointmentDataSvc), typeof(AppointmentDataSvc), ServiceLifetime.Scoped));
builder.Services.AddScoped<IAppointmentDataSvc, AppointmentDataSvc>();

builder.Services.Add(new ServiceDescriptor(typeof(IAppointmentServiceDataSvc), typeof(AppointmentServiceDataSvc), ServiceLifetime.Scoped));
builder.Services.AddScoped<IAppointmentServiceDataSvc, AppointmentServiceDataSvc>();

builder.Services.Add(new ServiceDescriptor(typeof(IBarberDataSvc), typeof(BarberDataSvc), ServiceLifetime.Scoped));
builder.Services.AddScoped<IBarberDataSvc, BarberDataSvc>();

builder.Services.Add(new ServiceDescriptor(typeof(IServiceDataSvc), typeof(ServiceDataSvc), ServiceLifetime.Scoped));
builder.Services.AddScoped<IServiceDataSvc, ServiceDataSvc>();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Service Endpoints
app.MapGet("/Service", (IServiceDataSvc contextService) =>
{
    return contextService.GetServices();
})
.WithName("GetServices")
.WithOpenApi();

app.MapGet("/Service/{id}", async (IServiceDataSvc contextService, int id, CancellationToken cancellationToken) =>
{
    return await contextService.GetServiceByIdAsync(id, cancellationToken);
})
.WithName("GetServiceById")
.WithOpenApi();
#endregion

#region Barber Endpoints
app.MapGet("/Barber/", (IBarberDataSvc contextService) =>
{
    return contextService.GetBarbers();
})
.WithName("GetBarbers")
.WithOpenApi();
#endregion

#region Appointment Endpoints
app.MapPost("/Appointment", async (IAppointmentDataSvc contextService, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
    return new { Id = await contextService.CreateAppointmentAsync(appointment, cancellationToken) };
})
.WithName("PostAppointment")
.WithOpenApi();

app.MapGet("/Appointment/{id}", async (IAppointmentDataSvc contextService, int id, CancellationToken cancellationToken) =>
{
    return await contextService.GetAppointmentByIdAsync(id, cancellationToken);
})
.WithName("GetAppointment")
.WithOpenApi();
app.MapGet("/Appointments", (IAppointmentDataSvc contextService, CancellationToken cancellationToken) =>
{
    var data = contextService.GetAppointmentsViewModel();
    return data;
})
.WithName("GetAppointments")
.WithOpenApi();
app.MapPut("/Appointment/{id}", async (IAppointmentDataSvc contextService, int id, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
    return new { Id = await contextService.UpdateAppointmentAsync(appointment, id, cancellationToken) };
})
.WithName("UpdateAppointment")
.WithOpenApi();
#endregion

#region Appointment Services Endpoints
app.MapPost("/AppointmentService/{appointmentId}", async (IAppointmentServiceDataSvc contextService, int appointmentId, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentServiceDto>();
    return new { Id = await contextService.CreateAppointmentServiceAsync(appointment, appointmentId, cancellationToken) };
})
.WithName("PostAppointmentService")
.WithOpenApi();

app.MapDelete("Appointment/AppointmentService/{appointmentId}", async (IAppointmentServiceDataSvc contextService, int appointmentId, CancellationToken cancellationToken) =>
{
    return new { AppointmentServiceIds = await contextService.DeleteAppointmentServicesByAppointmentIdAsync(appointmentId, cancellationToken) };
})
.WithName("DeleteAppointmentServices")
.WithOpenApi();

app.MapDelete("/AppointmentService/{appointmentServiceId}", async (IAppointmentServiceDataSvc contextService, int appointmentServiceId, CancellationToken cancellationToken) =>
{
    return new { AppointmentServiceId = await contextService.DeleteAppointmentServiceByIdAsync(appointmentServiceId, cancellationToken) };
})
.WithName("DeleteAppointmentService")
.WithOpenApi();
#endregion

app.Run();
