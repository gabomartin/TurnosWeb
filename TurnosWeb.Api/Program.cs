using TurnosWeb.Data;
using TurnosWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using TurnosWeb.Services.Interfaces;
using TurnosWeb.Services.Services;
using TurnosWeb.Data.Dtos;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationManager().AddJsonFile("appSettings.json").Build();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TurnosWebContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.Add(new ServiceDescriptor(typeof(IContextService), typeof(TurnosWebContextService), ServiceLifetime.Scoped));
builder.Services.AddScoped<IContextService, TurnosWebContextService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Service 
app.MapGet("/Service", (IContextService contextService) =>
{
    return contextService.GetServices();
})
.WithName("GetServices")
.WithOpenApi();

app.MapGet("/Service/{id}", async (IContextService contextService, int id, CancellationToken cancellationToken) =>
{
    return await contextService.GetServiceById(id, cancellationToken);
})
.WithName("GetServiceById")
.WithOpenApi();

//Barber
app.MapGet("/Barber/", (IContextService contextService) =>
{
    return contextService.GetBarbers();
})
.WithName("GetBarbers")
.WithOpenApi();

//Appointment
app.MapPost("/Appointment", async (IContextService contextService, HttpRequest req) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
    return new { Id = await contextService.CreateAppointment(appointment) };
})
.WithName("PostAppointment")
.WithOpenApi();

app.MapGet("/Appointment/{id}", async (IContextService contextService, int id, CancellationToken cancellationToken) =>
{
    return await contextService.GetAppointmentById(id, cancellationToken);
})
.WithName("GetAppointment")
.WithOpenApi();

app.MapPut("/Appointment/{id}", async (IContextService contextService, int id, HttpRequest req, CancellationToken cancellationToken) =>
{
    var appointment = await req.ReadFromJsonAsync<AppointmentDto>();
    return new { Id = await contextService.UpdateAppointment(appointment, id, cancellationToken) };
})
.WithName("UpdateAppointment")
.WithOpenApi();

app.Run();

