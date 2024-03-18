using LLS.Domain.Enumerations;

namespace LLS.Api;

public static class AddPolicyExtension
{
    public static IServiceCollection AddPolicies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthorizationBuilder()
            .AddPolicy(RoleEnum.Admin,p=>p.RequireRole(RoleEnum.Admin))
            .AddPolicy(RoleEnum.User,p=>p.RequireRole(RoleEnum.User));
        return serviceCollection;
    }
}