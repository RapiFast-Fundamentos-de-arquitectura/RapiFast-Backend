using SmartStay.Bookings.API.Domain.Model.Aggregates;
using SmartStay.Bookings.API.Domain.Model.Queries;
using SmartStay.Bookings.API.Domain.Repositories;
using SmartStay.Bookings.API.Domain.Services;

namespace SmartStay.Bookings.API.Application.Internal.QueryServices;

/// <summary>
/// Service implementation for handling booking queries.
/// Retrieves booking data from the repository.
/// </summary>
public class BookingQueryService(IBookingRepository bookingRepository)
    : IBookingQueryService
{
    /// <summary>
    /// Handles the query to retrieve a booking by its identifier.
    /// </summary>
    /// <param name="query">The query containing the booking ID.</param>
    /// <returns>The booking or null if not found.</returns>
    public async Task<Booking?> Handle(GetBookingByIdQuery query)
    {
        return await bookingRepository.FindByIdAsync(query.BookingId);
    }

    /// <summary>
    /// Handles the query to retrieve all bookings.
    /// </summary>
    /// <param name="query">The query to list all bookings.</param>
    /// <returns>A collection of all bookings.</returns>
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query)
    {
        return await bookingRepository.ListAsync();
    }

    /// <summary>
    /// Handles the query to retrieve bookings by room identifier.
    /// </summary>
    /// <param name="query">The query containing the room ID.</param>
    /// <returns>A collection of bookings associated with the specified room.</returns>
    public async Task<IEnumerable<Booking>> Handle(GetBookingsByRoomIdQuery query)
    {
        var bookings = await bookingRepository.ListAsync();
        return bookings.Where(b => b.RoomId == query.RoomId);
    }
}
