using AuthenticationService.Models;
using AutoMapper;

namespace AuthenticationService.DTO.Profiles
{
    public class authenticationProfile: Profile
    {
        public authenticationProfile()
        {
            CreateMap<UserRegistrationDto, User>(); 
        }
    }
}
