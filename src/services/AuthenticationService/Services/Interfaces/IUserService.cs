using AuthenticationService.DTO;
using AuthenticationService.Models;

namespace AuthenticationService.Services.Interfaces
{
    public interface IUserService
    {
        void RegisterNewUser(User userModel);

    }
}
