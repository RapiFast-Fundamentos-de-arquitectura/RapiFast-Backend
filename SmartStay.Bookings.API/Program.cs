using Microsoft.EntityFrameworkCore;
using SmartStay.Bookings.API.Domain.Repositories;
using SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Repositories;
using SmartStay.Bookings.API.Domain.Services;
using SmartStay.Bookings.API.Application.Internal.CommandServices;
using SmartStay.Bookings.API.Application.Internal.QueryServices;
using SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la cadena de conexión independiente
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookingsDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Registrar dependencias del microservicio
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();