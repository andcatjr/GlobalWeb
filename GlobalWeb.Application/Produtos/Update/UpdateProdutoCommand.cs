using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Produtos.Update;

public sealed record UpdateProdutoCommand :  ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

