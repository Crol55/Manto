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
        private static readonly SigningCredentials _asymmetricSigningCredentials;
        public AsymmetricJwtTokenGenerator(IOptions<JwtOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;
        }

        // static constructor, will be executed ONCE per instance.
        static AsymmetricJwtTokenGenerator() {

            string privateKey = File.ReadAllText("private.xml");

            RSA rsa = RSA.Create();
            rsa.FromXmlString(privateKey);

            var rsaSecurityKey = new RsaSecurityKey(rsa);

            _asymmetricSigningCredentials = new SigningCredentials(
                rsaSecurityKey, 
                SecurityAlgorithms.RsaSha256);
        }


        public string GenerateToken(string email)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationInMinutes),
                signingCredentials: _asymmetricSigningCredentials
            );;

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
