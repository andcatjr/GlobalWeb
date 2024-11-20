using Application.Abstractions.Messaging;
using GlobalWeb.Application.Produtos.GetById;

namespace GlobalWeb.Application.Produtos.GetById;

public record GetProdutoByIdQuery(Guid ProdutoId) : IQuery<ProdutoResponse>;