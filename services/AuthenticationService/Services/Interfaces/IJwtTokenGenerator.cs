namespace AuthenticationService.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(string userGuid);
    }
}
