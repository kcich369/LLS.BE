using LLS.Domain.Results;
using LLS.Identity.Database.Commands;

namespace LLS.Domain.Interfaces;

public interface ILoginService
{
    Task<IResult<string>> Login(LoginUser loginUser);
}