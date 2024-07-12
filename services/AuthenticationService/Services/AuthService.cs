using AuthenticationService.Data;
using AuthenticationService.Errors;
using AuthenticationService.Services.Interfaces;

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
            var userRegistered = _authenticationDbContext.User
                .FirstOrDefault(x => x.Username == EmailOrUsername || x.Email == EmailOrUsername);

            if (userRegistered == null)
                throw new NotFoundException("The information provided is Incorrect");

            // verify password
            if (_passwordHashingService.VerifyPassword(password, userRegistered.Password))
            {
                Console.WriteLine("Generating JWT TOKEN.....");
                var jwtToken = _jwtTokenGenerator.GenerateToken(EmailOrUsername);
                Console.WriteLine(jwtToken);

            }
            else
                throw new ValidationException("Your password doesnt match!");


            return "JWT Generated";
        }
    }
}
