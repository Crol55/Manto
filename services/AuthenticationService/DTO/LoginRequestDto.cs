using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.DTO
{
    public class LoginRequestDto
    {
        /*
            Referenced types have an implicit [required]
            if <nullable> is active in the project
        */
        [MaxLength(50)]
        public string EmailOrUsername { get; set; }

        [MaxLength(45)]
        public string Password { get; set; }

    }
}
