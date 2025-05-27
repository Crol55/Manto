using BoardsService.Models;

namespace BoardsService.DTO.Extensions
{
    public static class DtoExtensions
    {
        public static Board ToBoard(this BoardCreateDto boardCreateDto) {

            return new Board()
            {
                Name = boardCreateDto.Name,
                ProjectId = boardCreateDto.ProjectId
            };
        }
        public static BoardResponseDto ToDTO(this Board board) {           

            return new BoardResponseDto(
                board.Id, 
                board.Name, 
                board.CreatedAt, 
                board.UserId,
                board.ProjectId
            );
        }

    }
}
