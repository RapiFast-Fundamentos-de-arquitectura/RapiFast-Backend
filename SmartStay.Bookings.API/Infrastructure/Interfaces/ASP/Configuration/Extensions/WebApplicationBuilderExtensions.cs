using SmartStay.Bookings.API.Application.Internal.CommandServices;
using SmartStay.Bookings.API.Application.Internal.QueryServices;
using SmartStay.Bookings.API.Domain.Repositories;
using SmartStay.Bookings.API.Domain.Services;
using SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Repositories;

namespace SmartStay.Bookings.API.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddBookingsContextServices(this WebApplicationBuilder builder)
    {
        // Bookings Bounded Context Injection Configuration

        // Repositories
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();

        // Command Services
        builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();

        // Query Services
        builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();
    }
}

