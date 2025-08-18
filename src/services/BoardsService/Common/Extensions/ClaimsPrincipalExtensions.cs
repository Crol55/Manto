using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ServiceExceptionsLibrary;

namespace BoardsService.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string GetUserIdOrThrow(this ClaimsPrincipal user) 
        {
            string? userId = user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new ValidationException($"The claim {JwtRegisteredClaimNames.Sub} was not provided");

            return userId;
        }
    }
}
