using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthenticationService.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(string email)
        {
            var signignCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("holamundomichatoholamundomichato")),
                SecurityAlgorithms.HmacSha256
            );

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: "authService",
                expires: DateTime.UtcNow,
                signingCredentials: signignCredentials
            );


            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
