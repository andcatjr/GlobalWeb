using Application.Abstractions.Messaging;

namespace GlobalWeb.Application.Produtos.Delete;

public sealed record DeleteProdutoCommand(Guid ProdutoId) : ICommand;
