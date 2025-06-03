using BoardsService.Common.Enums;
using BoardsService.Models;

namespace BoardsService.Services.Interfaces
{
    public interface IBoardMemberService
    {
        //void AddMember(Guid boardId, Guid priviligedUserId, Guid targetUserId, string roleToAssign);
        Task<BoardMember> AddUserAsBoardMemberAsync(Guid targetBoardId, Guid targetUserId, Roles roleToAssign);

        bool VerifyUserMembership(Guid boardId, Guid userId);

        Roles GetUserRole(Guid userId, Guid boardId);
    }
}
