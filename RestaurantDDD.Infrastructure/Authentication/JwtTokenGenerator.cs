using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantDDD.Application.Common.Interfaces.Authentication;
using RestaurantDDD.Domain.UserAggregate;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantDDD.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256
                );
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName , user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName , user.LastName),
                 new Claim(JwtRegisteredClaimNames.Jti , user.Id.ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpiresInDays)
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
