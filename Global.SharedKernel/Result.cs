using System.Diagnostics.CodeAnalysis;

namespace Global.SharedKernel;

public class Result
{
    public bool isSuccess { get; }
    public bool isFailure => !isSuccess;
    public Error Error { get; set; }

    public Result(bool success, Error error)
    {
        isSuccess = success;
        Error = error;
    }
    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) =>
        new(default, false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool success, Error error)
        : base(success, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => isSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    public static Result<TValue> ValidationFailure(Error error) =>
        new(default, false, error);
}
