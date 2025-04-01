using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AuthenticationService.Configuration;
using AuthenticationService.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Services
{
    public class AsymmetricJwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        private readonly SigningCredentials _asymmetricSigningCredentials;
        public AsymmetricJwtTokenGenerator(IOptions<JwtOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;

            //string privateKey = File.ReadAllText("private.xml");
            if (string.IsNullOrEmpty(_jwtOptions.SecretKey))
                throw new InvalidOperationException("Private Key not found.");

            RSA rsa = RSA.Create();
            rsa.FromXmlString(_jwtOptions.SecretKey);

            var rsaSecurityKey = new RsaSecurityKey(rsa);

            _asymmetricSigningCredentials = new SigningCredentials(
                rsaSecurityKey,
                SecurityAlgorithms.RsaSha256);
        }

        public string GenerateToken(string userGuid)
        {
            // http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
            
            var userClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userGuid)
            };
            
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationInMinutes),
                signingCredentials: _asymmetricSigningCredentials, 
                claims: userClaims
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
