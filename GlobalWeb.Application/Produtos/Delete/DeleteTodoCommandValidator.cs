using FluentValidation;
using GlobalWeb.Application.Produtos.Delete;

namespace Application.Todos.Delete;

internal sealed class DeleteTodoCommandValidator : AbstractValidator<DeleteProdutoCommand>
{
    public DeleteTodoCommandValidator()
    {
        RuleFor(c => c.ProdutoId).NotEmpty();
    }
}
