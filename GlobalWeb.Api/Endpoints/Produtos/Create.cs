using Global.SharedKernel;
using GlobalWeb.Api.Endpoints.Usuarios;
using GlobalWeb.Api.Extensions;
using GlobalWeb.Api.Infrastructure;
using GlobalWeb.Application.Produtos.Create;
using MediatR;

namespace GlobalWeb.Api.Endpoints.Produtos;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("produtos", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateProdutoCommand
            {
                Name = request.Name,
                Price = request.Price
            };

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        }).WithTags(Tags.Produtos).RequireAuthorization();
    }
}