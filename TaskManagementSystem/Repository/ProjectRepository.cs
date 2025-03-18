using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;
using TaskManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystem.Repository{

    public class ProjectRepository : IProject
    {
        private readonly TaskManagementDbContext _dbContext;
        
        public ProjectRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Project> CreateProjectAsync(Project project)
        {
            await _dbContext.projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> GetProject(int Id)
        {
            var project = await _dbContext.projects.Where(p => p.Id == Id)
            .FirstOrDefaultAsync();
            return project;

        }

        public async Task<ICollection<Project>> GetProjectsAsync()
        {
            var projects = await _dbContext.projects.ToListAsync();
            return projects;
        }
//check this method soon
        public async Task<ICollection<WorkItem>> GetWorkItemsInProject(int projectId)
        {
            var project = await _dbContext.projects.Include(p => p.WorkItems)
            .FirstOrDefaultAsync(p=> p.Id == projectId);
            ;
            return project.WorkItems;

        }
//
        public async Task<bool> UpdateProjectAsync(Project project)
        {
             _dbContext.Update(project);
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0? true : false;
        }
    }
}