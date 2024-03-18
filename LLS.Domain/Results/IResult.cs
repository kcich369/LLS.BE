using LLS.Domain.Enumerations;

namespace LLS.Domain.Results;

public interface IResult
{
    public bool IsError { get; }
    public ResultInfo Info { get; }
}

public class ResultInfo
{
    public int TypeCode { get; set; }
    public int ErrorCode { get; set; }

    public StatusCodeEnumerations StatusCode { get; set; }
    public string ErrorMessage { get; set; }
}

public interface IResult<out T> : IResult
{
    public T Data { get; }
}