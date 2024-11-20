using FluentValidation;

namespace GlobalWeb.Application.Produtos.Create;

public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    public CreateProdutoCommandValidator()
    {
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(255);
    }
}
