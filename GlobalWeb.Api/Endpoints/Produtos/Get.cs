using Global.SharedKernel;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Api.Infrastructure;
using GlobalWeb.Application.Produtos.Get;
using MediatR;

namespace GlobalWeb.Api.Endpoints.Produtos;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("produtos", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetAllQuery();

            Result<List<ProdutoResponse>> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        }).WithTags(Tags.Produtos);
    }
}