using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Usuarios.Register;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password)
    : ICommand<Guid>;
