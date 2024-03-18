using LLS.Domain.Dtos;
using LLS.Domain.Results;

namespace LLS.Domain.ExternalServices;

public interface IEmailService
{
    Task<IResult<bool>> Send(EmailData emailData);
}