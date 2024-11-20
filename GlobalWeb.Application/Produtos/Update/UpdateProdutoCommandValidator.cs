using FluentValidation;

namespace GlobalWeb.Application.Produtos.Update;

public class UpdateProdutoCommandValidator : AbstractValidator<UpdateProdutoCommand>
{
    public UpdateProdutoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).MaximumLength(255);
    }
}