using BoardsService.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public static BoardList ToBoardList(this ListCreateDto dto) { 
        
            return new BoardList() 
            { 
                Name = dto.Name,
                Position = dto.Position!.Value,
                BoardId = dto.BoardId!.Value
            };
        }

        public static ListResponseDto ToDto(this BoardList boardList) {

            return new ListResponseDto(
                Id: boardList.Id,
                Name: boardList.Name,
                Position: boardList.Position,
                BoardId: boardList.BoardId
            );
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
