﻿using BoardsService.Common.Enums;
using BoardsService.Data;
using BoardsService.DTO;
using BoardsService.DTO.Extensions;
using BoardsService.Models;
using BoardsService.Services.Interfaces;
using ServiceExceptionsLibrary;

namespace BoardsService.Services
{
    public class ListService : IListService
    {
        private readonly BoardsDbContext _dbContext;
        private readonly IBoardMemberService _boardMemberService;

        public ListService(BoardsDbContext boardsDbContext, IBoardMemberService boardMemberService) 
        {
            _dbContext = boardsDbContext;
            _boardMemberService = boardMemberService;
        }

        private bool HasEditingPermission(Guid boardId, Guid userId)
        {

            return false;
        }


        public BoardList AddList(ListCreateDto dto, Guid RegisteredUserId)
        {
            BoardList newBoardList = dto.ToBoardList();
                newBoardList.UpdatedAt = DateTime.Now;

            Roles userRole = _boardMemberService.GetUserRole(RegisteredUserId, newBoardList.BoardId);
            if (userRole == Roles.None)
                throw new ForbiddenAccessException("You dont have access to this Resource");
                
            if (_dbContext.BoardLists.Any(
                l => l.Name == newBoardList.Name && 
                l.BoardId == newBoardList.BoardId))
                throw new DuplicatedEntryException($"The list:'{newBoardList.Name}' already exists in the Board");

            try {

                _dbContext.BoardLists.Add(newBoardList);

                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return newBoardList;
        }
    }
}
