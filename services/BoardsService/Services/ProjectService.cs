using BoardsService.Data;
using BoardsService.Models;
using BoardsService.Services.Interfaces;
using ServiceExceptionsLibrary;

namespace BoardsService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly BoardsDbContext _dbContext;
        public ProjectService(BoardsDbContext dbContext) 
        {
            _dbContext = dbContext;    
        }

        public void AddNewProject(Project project)
        {
            if (_dbContext.Projects.FirstOrDefault(p => p.Nombre == project.Nombre) is not null)
            {
                throw new ValidationException($"The project with name:'{project.Nombre}' is duplicated");
            }

            project.Id = Guid.NewGuid().ToString();
            project.UpdatedAt = DateTime.Now;
            
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }
    }
}
