using GlobalWeb.Domain.Usuarios;

namespace GlobalWeb.Application.Interfaces.Authentication;

public interface ITokenProvider
{
    string Create(Usuario usuario);
}