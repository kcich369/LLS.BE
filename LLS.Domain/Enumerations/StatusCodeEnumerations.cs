namespace LLS.Domain.Enumerations;

public class StatusCodeEnumerations(int id, string name) : Base.Enumerations(id, name)
{
    public static StatusCodeEnumerations Ok = new StatusCodeEnumerations(200, nameof(Ok));
    public static StatusCodeEnumerations BadRequest = new StatusCodeEnumerations(400, nameof(BadRequest));
    public static StatusCodeEnumerations Unauthorized = new StatusCodeEnumerations(401, nameof(Unauthorized));
    public static StatusCodeEnumerations NotFound = new StatusCodeEnumerations(404, nameof(NotFound));
    public static StatusCodeEnumerations InternalServerError = new StatusCodeEnumerations(500, nameof(NotFound));
}