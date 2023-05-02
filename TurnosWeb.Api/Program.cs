using TurnosWeb.Data;
using Microsoft.EntityFrameworkCore;
using TurnosWeb.Services.Interfaces;
using TurnosWeb.Services.Services;
using TurnosWeb.Data.Dtos;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationManager().AddJsonFile("appSettings.json").Build();

builder.Services.AddDbContext<TurnosWebContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.Add(new ServiceDescriptor(typeof(IContextService), typeof(TurnosWebContextService), ServiceLifetime.Scoped));
builder.Services.AddScoped<IContextService, TurnosWebContextService>();

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
app.MapGet("/Service", (IContextService contextService) =>
{
    return contextService.GetServices();
})
.WithName("GetServices")
.WithOpenApi();

app.MapGet("/Service/{id}", async (IContextService contextService, int id, CancellationToken cancellationToken) =>
{
    return await contextService.GetServiceByIdAsync(id, cancellationToken);
})
.WithName("GetServiceById")
.WithOpenApi();
#endregion

#region Barber Endpoints
app.MapGet("/Barber/", (IContextService contextService) =>
{
    return contextService.GetBarbers();
})
.WithName("GetBarbers")
.WithOpenApi();
#endregion

#region Appointment Endpoints
app.MapPost("/Appointment", async (IContextService contextService, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
    return new { Id = await contextService.CreateAppointmentAsync(appointment, cancellationToken) };
})
.WithName("PostAppointment")
.WithOpenApi();

app.MapGet("/Appointment/{id}", async (IContextService contextService, int id, CancellationToken cancellationToken) =>
{
    return await contextService.GetAppointmentByIdAsync(id, cancellationToken);
})
.WithName("GetAppointment")
.WithOpenApi();

app.MapGet("/Appointments", (IContextService contextService, CancellationToken cancellationToken) =>
{
    return contextService.GetAppointments();
})
.WithName("GetAppointments")
.WithOpenApi();

app.MapPut("/Appointment/{id}", async (IContextService contextService, int id, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
    return new { Id = await contextService.UpdateAppointmentAsync(appointment, id, cancellationToken) };
})
.WithName("UpdateAppointment")
.WithOpenApi();
#endregion

#region Appointment Services Endpoints
app.MapPost("/AppointmentService/{appointmentId}", async (IContextService contextService, int appointmentId, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentServiceDto>();
    return new { Id = await contextService.CreateAppointmentServiceAsync(appointment, appointmentId, cancellationToken) };
})
.WithName("PostAppointmentService")
.WithOpenApi();

app.MapDelete("Appointment/AppointmentService/{appointmentId}", async (IContextService contextService, int appointmentId, CancellationToken cancellationToken) =>
{
    return new { AppointmentServiceIds = await contextService.DeleteAppointmentServicesByAppointmentIdAsync(appointmentId, cancellationToken) };
})
.WithName("DeleteAppointmentServices")
.WithOpenApi();

app.MapDelete("/AppointmentService/{appointmentServiceId}", async (IContextService contextService, int appointmentServiceId, CancellationToken cancellationToken) =>
{
    return new { AppointmentServiceId = await contextService.DeleteAppointmentServiceByIdAsync(appointmentServiceId, cancellationToken) };
})
.WithName("DeleteAppointmentService")
.WithOpenApi();
#endregion

app.Run();
