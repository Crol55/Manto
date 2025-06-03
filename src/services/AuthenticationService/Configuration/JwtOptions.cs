namespace AuthenticationService.Configuration
{
    public class JwtOptions
    {
        public const string SectionName = "JwtSettings";
        public string? SecretKey { get; init; }
        public string? Issuer { get; init; }
        public double ExpirationInMinutes { get; init; }
    }
}
