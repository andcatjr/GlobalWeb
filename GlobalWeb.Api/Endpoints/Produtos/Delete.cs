using Global.SharedKernel;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Api.Infrastructure;
using GlobalWeb.Application.Produtos.Delete;
using MediatR;

namespace GlobalWeb.Api.Endpoints.Produtos;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("produtos/{produtoId}", async (Guid produtoId, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new DeleteProdutoCommand(produtoId);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        }).WithTags(Tags.Produtos).RequireAuthorization();
    }
}