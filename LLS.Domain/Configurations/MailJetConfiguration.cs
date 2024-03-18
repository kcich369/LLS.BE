using LLS.Domain.Configurations.Base;

namespace LLS.Domain.Configurations;

public class MailJetConfiguration : IConfiguration
{
    public string ApiKey { get; set; }
    public string ApiKeySecret { get; set; }
    public string From { get; set; }
}