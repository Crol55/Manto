using BoardsService.DTO;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using ServiceExceptionsLibrary;
using BoardsService.Services.Interfaces;
using BoardsService.Models;
using Microsoft.AspNetCore.Authorization;
using Asp.Versioning;
using BoardsService.DTO.Extensions;
using BoardsService.Common.Extensions;

namespace BoardsService.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion(1.0)]
    [Route("[controller]")]
    public class BoardsController: ControllerBase
    {
        private readonly IBoardService _boardService;
        public BoardsController(IBoardService boardService) {
            _boardService = boardService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBoard(BoardCreateDto boardCreateDto) {

            string? userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            // VERIFY THAT THE USERID IS NOT NULL
            if (string.IsNullOrEmpty(userId))
                throw new ValidationException($"The claim {JwtRegisteredClaimNames.Sub} was not provided");

            if (!Guid.TryParse(userId, out Guid parsedUserId))
                throw new ValidationException("Your userId is not well-formatted");

            Board createdBoard = await _boardService.AddNewBoard(boardCreateDto, parsedUserId);

            return CreatedAtAction(nameof(GetBoard), new { id = createdBoard.Id }, createdBoard.ToDTO());
        }


        [HttpGet ("{id:guid}")]
        public ActionResult GetBoard(Guid id) { 
        
            return Ok();
        }

        [HttpGet()]
        public ActionResult GetBoardsFromUser() {

            string userId = User.GetUserIdOrThrow();

            IEnumerable<BoardMembershipDetailDto> myBoards = _boardService.GetAllBoardsFromUser( Guid.Parse(userId) );

            return Ok(myBoards);
        }
    }
}
