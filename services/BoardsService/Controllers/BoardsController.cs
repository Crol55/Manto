using Microsoft.AspNetCore.Mvc;

namespace BoardsService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardsController: ControllerBase
    {
        [HttpPost]
        public IActionResult CreateBoard() {

            return Ok("your board will be created");
        }
    }
}
