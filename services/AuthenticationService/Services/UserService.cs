using AuthenticationService.Data;
using AuthenticationService.Models;
using AuthenticationService.Services.Interfaces;
using AuthenticationService.Errors;

namespace AuthenticationService.Services
{
    public class UserService: IUserService
    {
        private readonly AuthenticationDbContext _authenticationDbContext;
        private readonly IPasswordHashingService _passwordHashingService;

        public UserService(AuthenticationDbContext authenticationDbContext, IPasswordHashingService passwordHashingService) 
        {
            _authenticationDbContext = authenticationDbContext;   
            _passwordHashingService = passwordHashingService;
        }

        public void RegisterNewUser(User newUser)
        {
            User? repeatedUser = _authenticationDbContext.User
                .FirstOrDefault(x => x.Username == newUser.Username || x.Email == newUser.Email);

            if (repeatedUser is not null)
            {
                if (newUser.Username == repeatedUser.Username)
                    throw new ValidationException($"The Username [{newUser.Username}], is already registered");

                if (newUser.Email == repeatedUser.Email)
                    throw new ValidationException($"The Email [{newUser.Email}], is already registered");
            }

            // hashing the password to ensure security
            newUser.Password = _passwordHashingService.HashPassword(newUser.Password);

            _authenticationDbContext.User.Add(newUser);
            
            _authenticationDbContext.SaveChanges();
        }
    }
}
