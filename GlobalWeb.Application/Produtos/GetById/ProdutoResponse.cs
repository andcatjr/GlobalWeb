namespace GlobalWeb.Application.Produtos.GetById;

public record ProdutoResponse()
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}