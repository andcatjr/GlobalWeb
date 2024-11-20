using Application.Abstractions.Messaging;
using Global.SharedKernel;
using GlobalWeb.Application.Interfaces.Authentication;
using GlobalWeb.Application.Interfaces.Data;
using GlobalWeb.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace GlobalWeb.Application.Produtos.Delete;

internal sealed class DeleteProdutoCommandHandler(IApplicationDbContext context, IUserContext userContext)
    : ICommandHandler<DeleteProdutoCommand>
{
    public async Task<Result> Handle(DeleteProdutoCommand command, CancellationToken cancellationToken)
    {
        Produto? produto = await context.Produtos
            .SingleOrDefaultAsync(p => p.Id == command.ProdutoId, cancellationToken);

        if (produto is null)
        {
            return Result.Failure(Error.Problem("404", "Produto não encontrado."));
        }

        context.Produtos.Remove(produto);

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
