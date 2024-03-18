using LLS.Domain.Dtos;

namespace LLS.Domain.Interfaces;

public interface IJwtTokenProvider
{
    string GenerateToken(UserData userData);
}