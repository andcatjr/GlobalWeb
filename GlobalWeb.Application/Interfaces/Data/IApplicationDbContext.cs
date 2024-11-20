using GlobalWeb.Domain.Produtos;
using GlobalWeb.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace GlobalWeb.Application.Interfaces.Data;

public interface IApplicationDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Produto> Produtos { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}