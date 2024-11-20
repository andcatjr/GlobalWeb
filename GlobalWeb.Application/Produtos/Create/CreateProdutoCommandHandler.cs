using Application.Abstractions.Messaging;
using Global.SharedKernel;
using GlobalWeb.Application.Interfaces.Authentication;
using GlobalWeb.Application.Interfaces.Data;
using GlobalWeb.Application.Produtos.Create;
using GlobalWeb.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Create;

internal sealed class CreateProdutoCommandHandler(
    IApplicationDbContext context,
    IUserContext userContext)
    : ICommandHandler<CreateProdutoCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProdutoCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(command.Name))
        {
            return Result.Failure<Guid>(Error.Problem("400", "O nome do produto não pode ser vazio."));
        }
        
        if(command.Price <= 0)
        {
            return Result.Failure<Guid>(Error.Problem("400", "O preço do produto não pode ser menor ou igual a zero."));
        }
        
        Produto? produto = await context.Produtos
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Name == command.Name, cancellationToken);
        
        if (produto is not null)
        {
            return Result.Failure<Guid>(Error.Conflict("400","Produto já cadastrado."));
        }

        produto = new Produto()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Price = command.Price,
            CreatedAt = DateTime.UtcNow.AddHours(-3),
            CreatedBy = userContext.UsuarioId.ToString()
        };
        
        context.Produtos.Add(produto);

        await context.SaveChangesAsync(cancellationToken);

        return produto.Id;
    }
}
