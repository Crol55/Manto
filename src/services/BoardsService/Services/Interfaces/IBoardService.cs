using BoardsService.DTO;
using BoardsService.Models;

namespace BoardsService.Services.Interfaces
{
    public interface IBoardService
    {
        Task<Board> AddNewBoard(BoardCreateDto dto, Guid userId);

        IEnumerable<BoardMembershipDetailDto> GetAllBoardsFromUser(Guid userId);

    }
}
