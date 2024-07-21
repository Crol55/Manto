using System.IdentityModel.Tokens.Jwt;
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
        public AsymmetricJwtTokenGenerator(IOptions<JwtOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;
        }


        public string GenerateToken(string email)
        {
            
            var privateKey = File.ReadAllText("private.xml"); 
            
            var rsa = RSA.Create();
            rsa.FromXmlString(privateKey);

            // pass it to RSAsecuritykey
            var rsaSecurityKey = new RsaSecurityKey(rsa);

            var asymmetricSigningCredentials = new SigningCredentials(
                rsaSecurityKey, SecurityAlgorithms.RsaSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationInMinutes),
                signingCredentials: asymmetricSigningCredentials
            );;

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
