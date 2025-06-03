using BoardsService.DTO;
using BoardsService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BoardsService.Models;
using System.IdentityModel.Tokens.Jwt;
using ServiceExceptionsLibrary;
using Microsoft.AspNetCore.Authorization;

namespace BoardsService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly IListService _listService;
        public ListsController(IListService listService) 
        { 
            _listService = listService;
        }

        [HttpPost]
        public ActionResult AddList(ListCreateDto listCreateDto) {
            
            string? userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new ValidationException($"The claim {JwtRegisteredClaimNames.Sub} was not provided");

            BoardList createdList = _listService.AddList(listCreateDto, Guid.Parse(userId));
            
            return CreatedAtAction(
                nameof(GetList), 
                new { listName = createdList.Name, boardId = createdList.BoardId}
                );
        }

        [HttpGet]
        public ActionResult GetList(string listName, Guid boardId) {

            return Ok(boardId + "" + listName);
        }
    }
}
