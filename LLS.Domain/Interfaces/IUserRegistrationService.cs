using LLS.Domain.Commands;
using LLS.Domain.Dtos;
using LLS.Domain.Results;

namespace LLS.Domain.Interfaces;

public interface IUserRegistrationService
{
    Task<IResult<UserCreatedDto>> Reqister(RegisterUser usrData);
}