using BoardsService.DTO;
using BoardsService.Models;

namespace BoardsService.Services.Interfaces
{
    public interface IListService
    {
        public BoardList AddList(ListCreateDto dto, Guid RegisteredUserId);

        public IEnumerable<BoardList> GetAllLists(Guid boardId);

        public void UpdateList(Guid listId, ListUpdateDto newListValues);
    }
}
