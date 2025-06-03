namespace AuthenticationService.Services.Interfaces
{
    public interface IPasswordHashingService
    {
        public string HashPassword(string originalPassword);

        public bool VerifyPassword(string originalPassword, string hashedPassword);
    }
}
