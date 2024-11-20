using Application.Abstractions.Messaging;
using Global.SharedKernel;
using GlobalWeb.Application.Interfaces.Authentication;
using GlobalWeb.Application.Interfaces.Data;
using GlobalWeb.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace GlobalWeb.Application.Produtos.Update;

public sealed class UpdateProdutoCommandHandler(IApplicationDbContext context, IUserContext userContext) : ICommandHandler<UpdateProdutoCommand>
{
    public async Task<Result> Handle(UpdateProdutoCommand command, CancellationToken cancellationToken)
    {
        Produto? produto = await context.Produtos.AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == command.Id,
                cancellationToken);
        if (produto is null)
        {
            return Result.Failure(Error.Problem("400","Produto não encontrado."));
        }
        
        produto.UpdatedBy = userContext.UsuarioId.ToString();
        produto.Price = command.Price > 0 ? command.Price : produto.Price;
        produto.Name = !string.IsNullOrEmpty(command.Name) ? command.Name : produto.Name;
        context.Produtos.Update(produto);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}