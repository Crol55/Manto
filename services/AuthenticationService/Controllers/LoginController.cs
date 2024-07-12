using AuthenticationService.DTO;
using AuthenticationService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService) 
        { 
            _authService = authService;
        }

        [HttpPost]
        public IActionResult UserLogin(LoginRequestDto loginRequestDto) 
        {

            var jwtTokenString = _authService.Login(loginRequestDto.EmailOrUsername, loginRequestDto.Password!);

            return Ok(jwtTokenString);
        }
    }
}
