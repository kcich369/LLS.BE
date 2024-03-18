using LLS.Database.IdentityModels;
using LLS.Domain.Enumerations.ApiResponseEnumeration;
using LLS.Domain.Interfaces;
using LLS.Domain.Results;
using LLS.Identity.Database.Commands;
using Microsoft.AspNetCore.Identity;

namespace LLS.Infrastructure.Services;

public class LoginService(UserManager<User> userManager, IJwtTokenProvider jwtTokenProvider) : ILoginService
{
    public async Task<IResult<string>> Login(LoginUser loginUser)
    {
        var user = await userManager.FindByEmailAsync(loginUser.Login);
        if (user is null)
            return Result<string>.Error(UserAuthApiResTypesEnumerations.InvalidLoginData);
        user = await userManager.FindByNameAsync(loginUser.Login);
        if (user is null)
            return Result<string>.Error(UserAuthApiResTypesEnumerations.InvalidLoginData);
        if (!await userManager.CheckPasswordAsync(user, loginUser.Password))
            return Result<string>.Error(UserAuthApiResTypesEnumerations.InvalidLoginData);
        
        var role = await userManager.GetRolesAsync(user);
        return Result<string>.Success(jwtTokenProvider.GenerateToken(user.ToUserData().SetRole(role)));
    }
}