using LLS.Database.IdentityModels;
using LLS.Domain.Commands;
using LLS.Domain.Interfaces;
using LLS.Domain.Results;
using Microsoft.AspNetCore.Identity;

namespace LLS.Infrastructure.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;

    public AuthService(UserManager<User> userManager, IJwtTokenProvider jwtTokenProvider)
    {
        _userManager = userManager;
    }

    public Task<IResult<bool>> Register(RegisterUser registerUser)
    {
        throw new NotImplementedException();
    }
}