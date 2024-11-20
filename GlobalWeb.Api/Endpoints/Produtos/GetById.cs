using Global.SharedKernel;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Api.Infrastructure;
using GlobalWeb.Application.Produtos.GetById;
using MediatR;

namespace GlobalWeb.Api.Endpoints.Produtos;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("produtos/{produtoId}", async (Guid produtoId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetProdutoByIdQuery(produtoId);

            Result<ProdutoResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        }).WithTags(Tags.Produtos).RequireAuthorization();
    }
}