using LLS.Api.MinimalApis;

namespace LLS.Api;

public static class RegisterMinimalApisExtensions
{
    public static void RegisterMinimalApis(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.AddAuthorisationApis();
    }
}