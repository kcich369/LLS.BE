using LLS.Domain.Enumerations.Base;

namespace LLS.Domain.Results;

public class Result : IResult
{
    public bool IsError { get; protected init; }
    public ResultInfo Info { get; private set; }

    protected Result()
    {
    }

    protected Result(ApiResponseTypesEnumerations apiResponseTypes, string errorMessage = null)
    {
        Info = new ResultInfo()
        {
            TypeCode = apiResponseTypes.Id,
            ErrorCode = apiResponseTypes.ErrorCode,
            ErrorMessage = string.IsNullOrEmpty(errorMessage) ? apiResponseTypes.ErrorMessage : errorMessage,
            StatusCode = apiResponseTypes.StatusCode
        };
        IsError = true;
    }

    protected Result(ApiResponseTypesEnumerations apiResponseTypes, params object[] values)
    {
        Info = new ResultInfo()
        {
            TypeCode = apiResponseTypes.Id,
            ErrorCode = apiResponseTypes.ErrorCode,
            ErrorMessage = string.Format(apiResponseTypes.ErrorMessagePattern, values),
            StatusCode = apiResponseTypes.StatusCode
        };
        IsError = true;
    }

    protected Result(ResultInfo info, bool isError)
    {
        Info = info;
        IsError = isError;
    }
}

public class Result<T> : Result, IResult<T>
{
    public T Data { get; private set; }

    private Result(T data)
    {
        Data = data;
        IsError = false;
    }

    private Result(ApiResponseTypesEnumerations apiResponseTypes, params object[] values) : base(apiResponseTypes,
        values)
    {
    }

    private Result(ResultInfo info, bool isError) : base(info, isError)
    {
    }

    public static Result<T> Success(T data) => new(data);

    public static Result<T> Error(IResult errorResult)
    {
        if (!errorResult.IsError)
            throw new ArgumentException("This kind of result is success");
        return new Result<T>(errorResult.Info, true);
    }

    public static Result<T> Error(ApiResponseTypesEnumerations apiResponseTypes, params object[] values) =>
        new Result<T>(apiResponseTypes, values);
}