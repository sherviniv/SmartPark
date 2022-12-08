using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartPark.Infrastructure.Identity;
public class JwtHandler : IJwtHandler
{
    private readonly JwtOptions _options;

    public JwtHandler(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateUserToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            }),
            Issuer = _options.Issuer,
            Expires = DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateDeviceToken(int deviceId, int parkingId, DateTime expireTime)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(CustomClaims.DeviceId,deviceId.ToString()),
                new Claim(CustomClaims.ParkingId,parkingId.ToString()),
            }),
            Issuer = _options.Issuer,
            Expires = expireTime,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
