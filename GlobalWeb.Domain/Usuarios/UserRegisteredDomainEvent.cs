using Global.SharedKernel;

namespace GlobalWeb.Domain.Usuarios;

public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;
