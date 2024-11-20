using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Usuarios.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
