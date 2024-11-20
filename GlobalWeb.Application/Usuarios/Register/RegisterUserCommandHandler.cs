using Application.Abstractions.Messaging;
using Global.SharedKernel;
using GlobalWeb.Application.Interfaces.Authentication;
using GlobalWeb.Application.Interfaces.Data;
using GlobalWeb.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace GlobalWeb.Application.Usuarios.Register;

internal sealed class RegisterUserCommandHandler(IApplicationDbContext context, IPasswordHasher passwordHasher)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (await context.Usuarios.AnyAsync(u => u.Email == command.Email, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new Usuario()
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            PasswordHash = passwordHasher.Hash(command.Password)
        };

        user.Raise(new UserRegisteredDomainEvent(user.Id));

        context.Usuarios.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
