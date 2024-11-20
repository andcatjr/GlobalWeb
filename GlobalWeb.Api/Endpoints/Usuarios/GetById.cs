using Global.SharedKernel;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Api.Infrastructure;
using GlobalWeb.Application.Usuarios.GetById;
using MediatR;
using Web.Api.Endpoints.Users;

namespace GlobalWeb.Api.Endpoints.Usuarios;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("usuarios/{userId}", async (Guid userId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetUserByIdQuery(userId);

            Result<UserResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        // .HasPermission(Permissions.UsersAccess)
        .WithTags(Tags.Usuarios);
    }
}
