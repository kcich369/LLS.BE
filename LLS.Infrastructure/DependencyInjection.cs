using System.Net.Http.Headers;
using FluentValidation;
using LLS.Domain.Configurations;
using LLS.Domain.ExternalServices;
using LLS.Domain.Interfaces;
using LLS.Infrastructure.Extensions;
using LLS.Infrastructure.ExternalServices;
using LLS.Infrastructure.Services;
using LLS.Infrastructure.Validators;
using Mailjet.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LLS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection serviceCollection,
        IConfigurationManager configurationBuilder)
    {
        var mailJetConfig = configurationBuilder.BindSection<MailJetConfiguration>();
        serviceCollection.AddHttpClient<IMailjetClient, MailjetClient>(client =>
        {
            client.UseBasicAuthentication(mailJetConfig.ApiKey, mailJetConfig.ApiKeySecret);
        });

        var smsPlanetConfig = configurationBuilder.BindSection<SmsPlanetConfiguration>();
        serviceCollection.AddHttpClient<ISmsService, SmsPlanetService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(smsPlanetConfig.BaseUrl);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", smsPlanetConfig.ApiKey);
        });

        serviceCollection.AddValidatorsFromAssemblyContaining<RegisterUserValidation>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
        serviceCollection.AddScoped<ILoginService, LoginService>();
        serviceCollection.AddScoped<IUserRegistrationService, UserRegistrationService>();
        serviceCollection.AddScoped<IEmailService, MailjetEmailService>();
        serviceCollection.AddScoped<ISmsService, SmsPlanetService>();
        serviceCollection.AddScoped<IUserTokenService, UserTokenService>();
        serviceCollection.AddScoped<IUserEmailAndPhoneVerificationService, UserEmailAndPhoneVerificationService>();
        serviceCollection.AddScoped<IUserUpdateDataService, UserUpdateDataService>();
        serviceCollection.AddScoped<IUserResetPasswordService, UserResetPasswordService>();
        serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();
        serviceCollection.AddScoped<IRandomStringGenerator, RandomStringGenerator>();

        return serviceCollection;
    }
}