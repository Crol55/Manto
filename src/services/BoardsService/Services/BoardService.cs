using System.Collections;
using BoardsService.Common.Enums;
using BoardsService.Data;
using BoardsService.DTO;
using BoardsService.DTO.Extensions;
using BoardsService.Models;
using BoardsService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceExceptionsLibrary;

namespace BoardsService.Services
{
    public class BoardService: IBoardService
    {
        private readonly BoardsDbContext _dbContext;
        private readonly IProjectService _projectService;
        private readonly IBoardMemberService _boardMemberService;
        public BoardService(BoardsDbContext dbContext, IProjectService projectService, IBoardMemberService boardMemberService)
        { 
            _dbContext = dbContext;
            _projectService = projectService;
            _boardMemberService = boardMemberService;
        }

        public async Task<Board> AddNewBoard(BoardCreateDto dto, Guid userId) {

            Board newBoard = dto.ToBoard();
            newBoard.UserId = userId;

            var isBoardDuplicated = await _dbContext.Boards
                .AnyAsync(b => (b.UserId == userId) && (b.ProjectId == newBoard.ProjectId) && (b.Name == newBoard.Name));

            if (isBoardDuplicated)
                throw new DuplicatedEntryException($"The Board with name:'{newBoard.Name}' is duplicated");

            // If user sends a projectid, it MUST exists! Otherwise when inserting in the database it will throw an error (foreign key)
            if (newBoard.ProjectId != null &&
                await _projectService.FindProyectByUserIdAsync(newBoard.ProjectId.Value, userId) == null)
            {
                throw new ValidationException($"The project:{newBoard.ProjectId}, doesnt exist for your user");
            }

            try
            {
                using var transaction = await _dbContext.Database.BeginTransactionAsync();

                _dbContext.Boards.Add(newBoard);

                await _dbContext.SaveChangesAsync();

                // Insert the users permission for his board
                await _boardMemberService.AddUserAsBoardMemberAsync(newBoard.Id, userId, Roles.Owner);

                await transaction.CommitAsync();
            }
            catch (Exception ex) {
                Console.WriteLine("Error in the database:" + ex);
            }

            return newBoard;
        }


        public IEnumerable<BoardMembershipDetailDto> GetAllBoardsFromUser(Guid userId) { // getboardsWhereUserIsMember

            var userBoards = _dbContext.BoardMembers
                .AsNoTracking()
                .Where(bm => bm.UserId == userId)
                .Select(x => new BoardMembershipDetailDto()
                {
                    BoardId = x.BoardId,
                    BoardName = x.Board.Name,
                    UserId = x.UserId,
                    JoiningDate = x.JoiningDate,
                    TypeOfMembership = x.Role.RoleName
                })
                .OrderBy(x => x.TypeOfMembership);

            return userBoards.ToList();
        }
    }
}
