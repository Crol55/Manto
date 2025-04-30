using BoardsService.Data;
using BoardsService.DTO;
using BoardsService.DTO.Extensions;
using BoardsService.Models;
using BoardsService.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceExceptionsLibrary;

namespace BoardsService.Services
{
    public class BoardService: IBoardService
    {
        private readonly BoardsDbContext _dbContext;
        private readonly IProjectService _projectService;
        public BoardService(BoardsDbContext dbContext, IProjectService projectService) { 
            _dbContext = dbContext;
            _projectService = projectService;
        }

        public async Task<Board> AddNewBoard(BoardCreateDto dto, Guid userId) {

            Board newBoard = dto.ToBoard();
            newBoard.UserId = userId;

            var isBoardDuplicated = await _dbContext.Boards
                .AnyAsync(b => (b.ProjectId == newBoard.ProjectId) && (b.Name == newBoard.Name));

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
                _dbContext.Boards.Add(newBoard);

                _dbContext.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine("Error in the database:" + ex);
            }

            return newBoard;
        }
    }
}
