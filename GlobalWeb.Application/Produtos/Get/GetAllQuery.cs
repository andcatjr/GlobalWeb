using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Produtos.Get;

public sealed record GetAllQuery() : IQuery<List<ProdutoResponse>>;