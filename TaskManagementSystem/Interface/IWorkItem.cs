using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interface
{
    public interface IWorkItem
    {   
        Task <ICollection<WorkItem>> GetWorkItems();
        Task<WorkItem> CreateWorkItemAsync (WorkItem workItem) ;
        Task <bool> UpdateWorkItemAsync (WorkItem existingworkItem);
        Task <WorkItem> GetWorkItem(int Id);
        Task<WorkItem> DeleteWorkItem(WorkItem workId);
        Task<bool> UpdateTaskStatus (WorkItem workStatus);
        Task<bool> WorkExist(int Id);
        
    }
}