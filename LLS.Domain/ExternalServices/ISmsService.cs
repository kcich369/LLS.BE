using LLS.Domain.Dtos;
using LLS.Domain.Results;

namespace LLS.Domain.ExternalServices;

public interface ISmsService
{
    Task<IResult<bool>> SendSms(SmsData smsData);
}