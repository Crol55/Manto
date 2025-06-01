using BoardsService.Common.Enums;

namespace BoardsService.Services.Interfaces
{
    public interface IBoardMemberService
    {
        //void AddMember(Guid boardId, Guid priviligedUserId, Guid targetUserId, string roleToAssign);

        bool VerifyUserMembership(Guid boardId, Guid userId);

        Roles GetUserRole(Guid userId, Guid boardId);
    }
}
