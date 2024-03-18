using LLS.Domain.Commands;
using LLS.Domain.Results;
using LLS.Identity.Database.Commands;

namespace LLS.Domain.Interfaces;

public interface IAuthService
{
    public Task<IResult<bool>> Register(RegisterUser registerUser);
}