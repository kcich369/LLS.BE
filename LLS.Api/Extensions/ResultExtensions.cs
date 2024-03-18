using LLS.Domain.Results;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace LLS.Api.Extensions;

public static class ResultExtensions
{
    public static IResult ToResult<T>(this IResult<T> result)
    {
        return result.Info.StatusCode.Id switch
        {
            StatusCodes.Status200OK => Results.Ok(result.Data),
            StatusCodes.Status400BadRequest => 
                Results.BadRequest(new ResultDto(result.Info.TypeCode,result.Info.ErrorCode, result.Info.ErrorMessage)),
            StatusCodes.Status404NotFound => 
                Results.NotFound(new ResultDto(result.Info.TypeCode,result.Info.ErrorCode, result.Info.ErrorMessage)),
            StatusCodes.Status500InternalServerError => Results.StatusCode(StatusCodes.Status500InternalServerError),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public record ResultDto(int ErrorType, int ErrorCode, string? ErrorMessage = null);