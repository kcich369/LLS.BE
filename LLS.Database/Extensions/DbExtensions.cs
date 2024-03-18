using LLS.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LLS.Database.Extensions;

public static class DbExtensions
{
    public static async Task MigrateDatabase(this IServiceCollection serviceCollection)
    {
        using var scope = serviceCollection.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<LlsIdentityDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}