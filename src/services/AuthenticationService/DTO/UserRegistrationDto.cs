
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.DTO
{
    public class UserRegistrationDto
    {
        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(45)] 
        public string Password { get; set; }

        [MaxLength(50)] 
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string? Apellido { get; set; }
    }
}
