using Application.Abstractions.Messaging;
using Global.SharedKernel;
using GlobalWeb.Application.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalWeb.Application.Produtos.GetById;

public sealed class GetProdutoByIdQueryHandler(IApplicationDbContext context) : IQueryHandler<GetProdutoByIdQuery, ProdutoResponse>
{
    public async Task<Result<ProdutoResponse>> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
    {
        ProdutoResponse? produto = await context.Produtos
            .Where(p => p.Id == request.ProdutoId)
            .Select(p => new ProdutoResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy
            })
            .SingleOrDefaultAsync(cancellationToken);
        
        if (produto is null) 
        {
            return Result.Failure<ProdutoResponse>(Error.Problem("404", "Produto não encontrado."));
        }
        
        return produto;
    }
}