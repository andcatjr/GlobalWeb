using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Usuarios.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
