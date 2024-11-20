using GlobalWeb.Domain.Usuarios;
using MediatR;

namespace GlobalWeb.Application.Usuarios.Register;

internal sealed class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
{
    public Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        
        return Task.CompletedTask;
    }
}
