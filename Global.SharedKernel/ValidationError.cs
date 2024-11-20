namespace Global.SharedKernel;

public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors) : base("Validation Error", "Um ou mais erros ocorreram", ErrorType.Validation)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new ValidationError(results.Where(r => r.isFailure).Select(r => r.Error).ToArray());
}