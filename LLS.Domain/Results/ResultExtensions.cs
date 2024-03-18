using LLS.Domain.Enumerations.Base;

namespace LLS.Domain.Results;

public static class ResultExtensions
{
    public static async Task<IResult<T>> TryCatch<T>(this Task<IResult<T>> task,
        ApiResponseTypesEnumerations apiResponseTypes, string errorMsg)
    {
        try
        {
            return await task;
        }
        catch
        {
            return Result<T>.Error(apiResponseTypes, errorMsg);
        }
    }
}