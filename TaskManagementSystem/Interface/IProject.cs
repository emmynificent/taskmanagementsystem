using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interface
{
    public interface IProject
    {
        Task<ICollection<Project>> GetProjectsAsync();
        Task<Project> GetProject(int Id);
        Task<Project> CreateProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
        //Task<Project> AddWorkItemToProject(WorkItem workItem);
        Task<ICollection<WorkItem>> GetWorkItemsInProject(int Id);
        
        
        // Task <WorkItem> AddWorkItemToProject(WorkItem workItem);
        
    }
}