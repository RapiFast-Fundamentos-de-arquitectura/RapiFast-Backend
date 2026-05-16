using SmartStay.Bookings.API.Domain.Model.Aggregates;
using SmartStay.Bookings.API.Domain.Repositories;
using SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Configuration;
using SmartStay.SharedKernel.Infrastructure.Persistence.EFC.Repositories;

namespace SmartStay.Bookings.API.Infrastructure.Persistence.EFC.Repositories;

public class BookingRepository(AppDbContext context) : BaseRepository<Booking>(context), IBookingRepository;

