using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Produtos.Create;

public sealed class CreateProdutoCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}
