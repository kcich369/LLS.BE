namespace LLS.Domain.Enumerations.Base;

public class ApiResponseTypesEnumerations : Enumerations
{
    public int ErrorCode { get; private set; }
    public string ErrorMessage { get; private set; }

    public StatusCodeEnumerations StatusCode { get; private set; }

    public string ErrorMessagePattern { get; private set; }

    protected ApiResponseTypesEnumerations(
        int typeCode,
        string typeName,
        int errorCode,
        string errorMessage,
        StatusCodeEnumerations statusCode,
        string errorMessagePattern = null
    ) : base(typeCode, typeName)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
        ErrorMessagePattern = errorMessagePattern;
    }
}