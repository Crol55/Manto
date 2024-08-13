using Microsoft.AspNetCore.Mvc;
using BoardsService.DTO;
using BoardsService.Models;
using BoardsService.Services.Interfaces;

namespace BoardsService.Controllers;

    [Route("[controller]")]
    [ApiController]
    public class ProjectsController: ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public IActionResult CreateNewProject(ProjectRequestDto projectRequestDto) {

            Project newProject = new() {
                Nombre = projectRequestDto.Nombre,
                UserId = "1b390c20-234e-4b42-9f19-19d1acfd5d00"
            };
            
            _projectService.AddNewProject(newProject);
            

            return Created();
        }

        
    }

