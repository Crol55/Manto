using BoardsService.Data;
using BoardsService.Models;
using BoardsService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BoardsService.Common.Enums;

namespace BoardsService.Services
{
    public class BoardMemberService : IBoardMemberService
    {
        private readonly BoardsDbContext _dbContext;

        public BoardMemberService(BoardsDbContext dbContext) { 
            _dbContext = dbContext;
        }

        public async Task<BoardMember> AddUserAsBoardMemberAsync(Guid targetBoardId, Guid targetUserId, Roles roleToAssign) 
        {
            var newBoardMember = new BoardMember() 
            {
                BoardId = targetBoardId,
                UserId = targetUserId,
                BoardRolesId = GetRoleIdByRoleName(roleToAssign)
            };

            _dbContext.BoardMembers.Add(newBoardMember);
            await _dbContext.SaveChangesAsync();

            return newBoardMember;
        }

        public bool VerifyUserMembership(Guid boardId, Guid userId)
        {
            return _dbContext.BoardMembers.Any(m => m.BoardId == boardId && m.UserId == userId);
        }

        public Roles GetUserRole (Guid userId, Guid boardId)
        {
            BoardMember? member = _dbContext.BoardMembers
                .Include( m => m.Role)
                .FirstOrDefault(m => (m.BoardId == boardId) && (m.UserId == userId));

            return member == null 
                ? Roles.None 
                : MapToRole(member.Role.RoleName);
        }

        private Roles MapToRole(string databaseRole) 
        {
            return databaseRole switch
            {
                "Owner"         => Roles.Owner,
                "Admin"         => Roles.Admin,
                "Collaborator"  => Roles.Collaborator,
                "Viewer"        => Roles.Viewer,
                _               => Roles.None,
            };
        }

        private byte GetRoleIdByRoleName(Roles roleToMap)
        {

            BoardRoles boardRoles = _dbContext.BoardRoles.First(br => br.RoleName == roleToMap.ToString());

            return boardRoles.Id;
        }
    }
}
