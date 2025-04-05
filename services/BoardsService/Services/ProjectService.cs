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

        public Project AddNewProject(string projectName, Guid userId)
        {
            IEnumerable<Project> projects = _dbContext.Projects
                .Where(p => (p.UserId == userId) && (p.Nombre == projectName))
                .ToList();

            /*if (!projects.Any()) 
            {
                throw new ValidationException($"The user is invalid");
            }*/
            
            if (projects.Any())
                throw new ValidationException($"The project with name:'{projectName}' is duplicated");
            

            Project newProject = new Project()
            {
                Nombre = projectName,
                UserId = userId
            };
            
            _dbContext.Projects.Add(newProject);
            _dbContext.SaveChanges();

            return newProject;
        }
    }
}
