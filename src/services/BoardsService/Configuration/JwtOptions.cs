namespace BoardsService.Configuration
{
    public class JwtOptions
    {
        public const string sectionName = "JwtSettings";

        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string PublicKey { get; set; } = string.Empty;

    }
}
