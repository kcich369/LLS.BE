using LLS.Database.IdentityModels;
using LLS.Domain.Enumerations;
using LLS.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LLS.Infrastructure.Services;

public interface IUserTokenService
{
    Task<bool> Set(User user, UserTokenEnum userTokenEnum, string token);
    Task<string> Get(User user, UserTokenEnum userTokenEnum);
    Task<string> GetActive(User user, UserTokenEnum userTokenEnum, TimeSpan expirationTime);
    Task<bool> Remove(User user, UserTokenEnum userTokenEnum);
}

public class UserTokenService : IUserTokenService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly UserManager<User> _userManager;

    public UserTokenService(UserManager<User> userManager,
        IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        _userManager = userManager;
    }

    public async Task<bool> Set(User user, UserTokenEnum userTokenEnum, string token)
    {
        var tokenDto = new TokenDto()
        {
            Value = token,
            CreatedAt = _dateTimeProvider.Now()
        };
        await _userManager.SetAuthenticationTokenAsync(user, userTokenEnum.Provider, userTokenEnum.Name,
            JsonSerializer.Serialize(tokenDto));
        return true;
    }

    public async Task<string> Get(User user, UserTokenEnum userTokenEnum)
    {
        var tokenDto = await GetToken(user, userTokenEnum);
        return tokenDto?.Value;
    }

    public async Task<string> GetActive(User user, UserTokenEnum userTokenEnum, TimeSpan expirationTime)
    {
        var tokenDto = await GetToken(user, userTokenEnum);
        if (tokenDto is null)
            return null;
        return tokenDto.CreatedAt.Add(expirationTime) >= _dateTimeProvider.Now() ? tokenDto.Value : null;
    }

    private async Task<TokenDto> GetToken(User user, UserTokenEnum userTokenEnum)
    {
        var token = await _userManager.GetAuthenticationTokenAsync(user, userTokenEnum.Provider, userTokenEnum.Name);
        return string.IsNullOrEmpty(token) ? null : JsonSerializer.Deserialize<TokenDto>(token);
    }

    public async Task<bool> Remove(User user, UserTokenEnum userTokenEnum)
    {
        await _userManager.RemoveAuthenticationTokenAsync(user, userTokenEnum.Provider, userTokenEnum.Name);
        return true;
    }
}

class TokenDto
{
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }
}