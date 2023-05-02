using System.Collections.Generic;
using TurnosWeb.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


var appointments = new List<Appointment>();

app.MapGet("/Appointment", () =>
{
    return 
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

