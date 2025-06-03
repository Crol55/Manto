using AuthenticationService.Services.Interfaces;
using BCrypt.Net;

namespace AuthenticationService.Services
{
    public class PasswordHashingService : IPasswordHashingService
    {
        public bool VerifyPassword(string originalPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(originalPassword, hashedPassword);
        }

        public string HashPassword(string originalPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(originalPassword);
        }
    }
}
