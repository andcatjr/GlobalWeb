using Global.SharedKernel;

namespace GlobalWeb.Domain.Produtos;

public sealed class Produto : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}