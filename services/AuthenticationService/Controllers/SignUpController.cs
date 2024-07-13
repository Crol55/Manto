using Microsoft.AspNetCore.Mvc;
using AuthenticationService.DTO;
using AuthenticationService.Services.Interfaces;
using AutoMapper;
using AuthenticationService.Models;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public SignUpController(IUserService userService, IMapper mapper) { 
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateUser(UserRegistrationDto userRegistrationDto) {

            var newUser = _mapper.Map<User>(userRegistrationDto);

            _userService.RegisterNewUser(newUser);

            return Created("", userRegistrationDto);
        }
       
    }
}
