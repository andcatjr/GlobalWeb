using Application.Abstractions.Messaging;
using Global.SharedKernel;
using GlobalWeb.Application.Interfaces.Authentication;
using GlobalWeb.Application.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalWeb.Application.Produtos.Get;

public sealed class GetAllQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetAllQuery, List<ProdutoResponse>>
{
    public async Task<Result<List<ProdutoResponse>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        List<ProdutoResponse> produtos = await context.Produtos.Select(produto => new ProdutoResponse
        {
            Id = produto.Id,
            Name = produto.Name,
            Price = produto.Price,
            CreatedAt = produto.CreatedAt,
            CreatedBy = produto.CreatedBy
        }).ToListAsync(cancellationToken);

        return produtos;
    }
}