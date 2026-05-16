using SmartStay.Bookings.API.Domain.Model.Aggregates;
using SmartStay.Bookings.API.Interfaces.REST.Resources;

namespace SmartStay.Bookings.API.Interfaces.REST.Transform;

public static class BookingResourceFromEntityAssembler
{

    public static BookingResource ToResourceFromEntity(Booking entity)
    {
        return new BookingResource(
            entity.Id,
            entity.RoomId,
            entity.GuestName,
            entity.GuestEmail,
            entity.CheckInDate,
            entity.CheckOutDate,
            entity.Status.ToString());
    }
}

