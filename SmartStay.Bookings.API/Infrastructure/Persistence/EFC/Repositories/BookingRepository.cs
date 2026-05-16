using SmartStay.Bookings.API.Domain.Model.Aggregates;
using SmartStay.Bookings.API.Domain.Repositories;
using SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Configuration.Extensions;
using SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Repositories;

namespace SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Repositories;

public class BookingRepository(BookingsDbContext context) : BaseRepository<Booking>(context), IBookingRepository;

