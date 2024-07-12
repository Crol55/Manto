namespace AuthenticationService.Services.Interfaces
{
    public interface IAuthService
    {
        public string Login (string EmailOrUsername, string password);
    }
}
