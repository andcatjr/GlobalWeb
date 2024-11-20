using Global.SharedKernel;

namespace GlobalWeb.Api.Extensions;

public static class ResultExtensions
{
    public static TOut Match<TOut>(this Result result, Func<TOut> onSuccess, Func<Result, TOut> onFailure)
    {
        return result.isSuccess ? onSuccess() : onFailure(result);
    }
    
    public static TOut Match<Tin,TOut>(this Result<Tin> result, Func<Tin,TOut> onSucess, Func<Result<Tin>,TOut> onFailure)
    {
        return result.isSuccess ? onSucess(result.Value) : onFailure(result);
    }
}