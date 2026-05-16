using SmartStay.Bookings.API.Domain.Model.Aggregates;
using SmartStay.SharedKernel.Domain.Repositories;

namespace SmartStay.Bookings.API.Domain.Repositories;

/// <summary>
/// Repository interface for managing Booking aggregates.
/// </summary>
public interface IBookingRepository : IBaseRepository<Booking>
{
}
