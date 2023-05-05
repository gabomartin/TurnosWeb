using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data;
using TurnosWeb.Services.Abstractions;
using TurnosWeb.Services.Services;
using TurnosWeb.Api.Mappings;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationManager().AddJsonFile("appSettings.json").Build();

builder.Services.AddDbContext<TurnosWebContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.Add(new ServiceDescriptor(typeof(IAppointmentDomainService), typeof(AppointmentDomainService), ServiceLifetime.Scoped));
builder.Services.AddScoped<IAppointmentDomainService, AppointmentDomainService>();

builder.Services.Add(new ServiceDescriptor(typeof(IAppointmentServiceDomainService), typeof(AppointmentServiceDomainService), ServiceLifetime.Scoped));
builder.Services.AddScoped<IAppointmentServiceDomainService, AppointmentServiceDomainService>();

builder.Services.Add(new ServiceDescriptor(typeof(IBarberDomainService), typeof(BarberDomainService), ServiceLifetime.Scoped));
builder.Services.AddScoped<IBarberDomainService, BarberDomainService>();

builder.Services.Add(new ServiceDescriptor(typeof(IServiceDomainService), typeof(ServiceDomainService), ServiceLifetime.Scoped));
builder.Services.AddScoped<IServiceDomainService, ServiceDomainService>();

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

app.MapAppointmentEndpoints();

app.MapAppointmentServiceEndpoints();

app.MapServiceEndpoints();

app.MapBarberEndpoints();

app.Run();
