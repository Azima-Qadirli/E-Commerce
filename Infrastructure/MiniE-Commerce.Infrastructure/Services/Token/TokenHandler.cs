using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniE_Commerce.Application.Abstractions.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MiniE_Commerce.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTO.Token CreateAccessToken(int minute)
        {
            Application.DTO.Token token = new();

            //We obtain the symmetry of the Security Key.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //We create the encrypted identity.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //We provide the settings for the token to be created.
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
