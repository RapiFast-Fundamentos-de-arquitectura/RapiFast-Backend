using Cortex.Mediator.Notifications;

namespace SmartStay.SharedKernel.Domain.Model.Events;

/// <summary>
/// Marker interface for domain events.
/// </summary>
public interface IEvent : INotification
{
}