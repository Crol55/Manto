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
    }
}
