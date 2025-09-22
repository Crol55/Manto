using BoardsService.DTO;
using BoardsService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BoardsService.Models;
using Microsoft.AspNetCore.Authorization;
using BoardsService.Common.Extensions;
using BoardsService.DTO.Extensions;
using System.ComponentModel.DataAnnotations;

namespace BoardsService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly IListService _listService;
        public ListsController(IListService listService)
        {
            _listService = listService;
        }

        [HttpPost]
        public ActionResult<ListResponseDto> AddList(ListCreateDto listCreateDto) {

            string userId = User.GetUserIdOrThrow();

            BoardList createdList = _listService.AddList(listCreateDto, Guid.Parse(userId));

            return CreatedAtAction(
                nameof(GetList),
                createdList.ToDto()
                );
        }

        [HttpGet]
        public ActionResult GetList(string listName, Guid boardId) {

            return Ok(new { resultado = listName });
        }


        [HttpGet("{boardId:guid}")]
        public ActionResult<IEnumerable<ListResponseDto>> GetAllLists(Guid boardId) {

            //Vefiry JWT
            User.GetUserIdOrThrow();

            return Ok(this._listService.GetAllLists(boardId).Select(x => x.ToDto()));
        }

        [HttpPatch("{listId:guid}")] 
        public IActionResult UpdateList(Guid listId, ListUpdateDto listUpdateDto) 
        {
            User.GetUserIdOrThrow();

            Console.WriteLine("Si ingreso al 'updatelist()'" + listId);
            Console.WriteLine(listUpdateDto);

            this._listService.UpdateList(listId, listUpdateDto);

            return Ok(new { msg = "update was received"});
        }
    }
}
