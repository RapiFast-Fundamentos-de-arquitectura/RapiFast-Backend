using SmartStay.Bookings.API.Domain.Model.Commands;
using SmartStay.Bookings.API.Interfaces.REST.Resources;

namespace SmartStay.Bookings.API.Interfaces.REST.Transform;

public static class CreateBookingCommandFromResourceAssembler
{
    public static CreateBookingCommand ToCommandFromResource(CreateBookingResource resource)
    {
        return new CreateBookingCommand(
            resource.RoomId,
            resource.GuestName,
            resource.GuestEmail,
            resource.CheckInDate,
            resource.CheckOutDate);
    }
}

