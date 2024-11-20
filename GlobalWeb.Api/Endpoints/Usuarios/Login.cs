using Global.SharedKernel;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Api.Infrastructure;
using GlobalWeb.Application.Usuarios.Login;
using MediatR;

namespace GlobalWeb.Api.Endpoints.Usuarios;

internal sealed class Login : IEndpoint
{
    public sealed record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("usuarios/login", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new LoginUserCommand(request.Email, request.Password);

            Result<string> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Usuarios);
    }
}
