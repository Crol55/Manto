using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("[controller]")]
    public class SignUp: ControllerBase
    {
        [HttpGet]
        public string AddNewUser() {

            return "tu usuario sera creado";
        }
       
    }
}
