using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LLS.Domain.Configurations;
using LLS.Domain.Dtos;
using LLS.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LLS.Infrastructure.Services;

public class JwtTokenProvider(JwtConfiguration config) : IJwtTokenProvider
{
    private readonly JwtConfiguration _config = config;

    public string GenerateToken(UserData userData)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,userData.Id),
            new Claim(ClaimTypes.Email,userData.Email),
            new Claim(ClaimTypes.MobilePhone,userData.PhoneNumber),
        };
        claims.AddRange(userData.Roles.Select(x=> new Claim(ClaimTypes.Role,x)));
       
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key));
        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var securityToken =
            new JwtSecurityToken(claims: claims, 
                expires: DateTime.Now.AddMinutes(config.ExpiresInMinutes),
                issuer: config.Issuer,
                audience: config.Audience,
                signingCredentials: signingCred);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}