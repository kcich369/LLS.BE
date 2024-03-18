using LLS.Domain.Dtos;
using LLS.Domain.ExternalServices;
using LLS.Domain.Results;

namespace LLS.Infrastructure.ExternalServices;

public class SmsPlanetService(HttpClient httpClient) : ISmsService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IResult<bool>> SendSms(SmsData smsData)
    {
        var response = await _httpClient.PostAsync("", new FormUrlEncodedContent(SmsContentDictionary(smsData)));
        var content = await response.Content.ReadAsStringAsync();
        return content.Contains("messageId") ? Result<bool>.Success(true) : Result<bool>.Success(false);
    }

    private static Dictionary<string, string> SmsContentDictionary(SmsData smsData1) =>
        new()
        {
            { SmsPlanetPropEnum.From, smsData1.From },
            { SmsPlanetPropEnum.To, smsData1.PhoneNumber },
            { SmsPlanetPropEnum.Message, smsData1.Text },
        };
}