using LLS.Domain.Configurations.Base;

namespace LLS.Domain.Configurations;

public class JwtConfiguration : IConfiguration
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresInMinutes { get; set; }
}