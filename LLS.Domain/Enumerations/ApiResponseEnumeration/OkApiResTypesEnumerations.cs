using LLS.Domain.Enumerations.Base;

namespace LLS.Domain.Enumerations.ApiResponseEnumeration;

public class OkApiResTypesEnumerations : ApiResponseTypesEnumerations
{
    public OkApiResTypesEnumerations Ok = new(0, nameof(Ok), StatusCodeEnumerations.Ok);

    protected OkApiResTypesEnumerations(int errorCode, string errorMessageTranslation,
        StatusCodeEnumerations statusCode) : base(0, "OK", errorCode, errorMessageTranslation, statusCode)
    {
    }
}