using LLS.Domain.Results;
using LLS.Domain.Dtos;

namespace LLS.Domain.Interfaces;

public interface IUserEmailAndPhoneVerificationService
{
    Task<IResult<bool>> Send(string userId);
    Task<IResult<bool>> Confirm(string userId, string emailToken, string phoneToken);
}