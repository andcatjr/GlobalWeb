using Global.SharedKernel;

namespace GlobalWeb.Domain.Usuarios;

public static class UserErrors
{
    public static Error NotFound(Guid userId) => Error.NotFound(
        "Users.NotFound",
        $"O usuário com o id = '{userId}' não foi encontrado");

    public static Error Unauthorized() => Error.Failure(
        "Users.Unauthorized",
        "Usuário não autorizado para essa ação");

    public static readonly Error NotFoundByEmail = Error.NotFound(
        "Users.NotFoundByEmail",
        "Nenhum usuário com este email encontrado");

    public static readonly Error EmailNotUnique = Error.Conflict(
        "Users.EmailNotUnique",
        "Email já registrado");
}
