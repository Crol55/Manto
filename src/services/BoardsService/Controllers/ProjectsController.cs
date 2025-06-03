using Microsoft.AspNetCore.Mvc;
using BoardsService.DTO;
using BoardsService.Models;
using BoardsService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using ServiceExceptionsLibrary;
using Asp.Versioning;

namespace BoardsService.Controllers;

    
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [ApiVersion(1.0)]
    public class ProjectsController: ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        public IActionResult CreateNewProject(ProjectRequestDto projectRequestDto) {

            string? userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            
            if (string.IsNullOrEmpty(userId))
                throw new ValidationException($"The claim {JwtRegisteredClaimNames.Sub} was not provided");
            
            /*Project newProject = new() 
            {
                Nombre = projectRequestDto.Nombre,
                UserId = Guid.Parse( userId )
            };*/
            
            var projectCreated = _projectService.AddNewProject( projectName: projectRequestDto.Nombre, userId: Guid.Parse(userId));
       
            return CreatedAtAction(nameof(GetProject), new { id = projectCreated.Id }, projectRequestDto);
        }


        [HttpGet ("{id:guid}")]
        [MapToApiVersion(1.0)]
        public IActionResult GetProject(Guid id)
        {
            Console.WriteLine("Guid failing");
            return Ok();
        }
        
    }

