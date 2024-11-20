using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Usuarios.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
