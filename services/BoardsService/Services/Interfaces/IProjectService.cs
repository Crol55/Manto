using BoardsService.Models;

namespace BoardsService.Services.Interfaces
{
    public interface IProjectService
    {
        Project AddNewProject(string projectName, Guid userId);
    }
}
