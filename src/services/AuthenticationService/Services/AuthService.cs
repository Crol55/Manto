using AuthenticationService.Data;
using AuthenticationService.Errors;
using AuthenticationService.Services.Interfaces;
using AuthenticationService.Models;

namespace AuthenticationService.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationDbContext _authenticationDbContext;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            AuthenticationDbContext authenticationDbContext, 
            IPasswordHashingService passwordHashingService,
            IJwtTokenGenerator jwtTokenGenerator
            )
        { 
            _authenticationDbContext = authenticationDbContext;
            _passwordHashingService = passwordHashingService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public string Login(string EmailOrUsername, string password)
        {
            // look for the user (Throw Error if required)
            User userRegistered = _authenticationDbContext.User
                .FirstOrDefault(x => x.Username == EmailOrUsername || x.Email == EmailOrUsername)
                ?? throw new NotFoundException("The information provided is Incorrect");

            // verify password
            if (_passwordHashingService.VerifyPassword(password, userRegistered.Password))
            {
                return _jwtTokenGenerator.GenerateToken(userRegistered.Id.ToString());
            }
            else
                throw new ValidationException("Your password doesnt match!");

        }
    }
}
