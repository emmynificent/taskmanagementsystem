using System.Data.Entity.Core.Common.EntitySql;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repository
{
    public class WorkRepository : IWorkItem
    {
        private readonly TaskManagementDbContext _tmanagementDbase;
        public WorkRepository(TaskManagementDbContext tmanagementDbase)
        {
            _tmanagementDbase = tmanagementDbase;  
        }

        public async Task<WorkItem> CreateWorkItemAsync(WorkItem workItem)
        {

            await _tmanagementDbase.workItems.AddAsync(workItem);
            
            var project = await _tmanagementDbase.projects
            .Include(p => p.WorkItems)
            .FirstOrDefaultAsync(p => p.Id == workItem.projectId);
            if(project == null)
            {
                throw new Exception("Project does not exist");
            }
            project.WorkItems?.Add(workItem);            

            await _tmanagementDbase.SaveChangesAsync();
            return workItem;

        }

        public async Task<WorkItem> DeleteWorkItem(WorkItem workItem)
        {
            _tmanagementDbase.workItems.Remove(workItem);
            await _tmanagementDbase.SaveChangesAsync();
            return workItem;
        }

        public async Task<WorkItem> GetWorkItem(int Id)
        {
            var work = await _tmanagementDbase.workItems
            .Where(q => q.Id == Id)
            .FirstOrDefaultAsync();
            return work;
        }

        public async Task<ICollection<WorkItem>> GetWorkItems()
        {
            var workItems = await _tmanagementDbase.workItems.ToListAsync();
            return workItems;
        }

        public async Task<bool> UpdateWorkItemAsync(WorkItem existingworkItem)
        {
            
            _tmanagementDbase.workItems.Update(existingworkItem);
            var saved = await _tmanagementDbase.SaveChangesAsync();
            return saved > 0 ? true : false;

        }

        public async Task<bool> UpdateTaskStatus(WorkItem workStatus)
        {
            _tmanagementDbase.workItems.Where(w => w.Id == workStatus.Id)
            .Include(w => w.status == workStatus.status);
            _tmanagementDbase.workItems.Update(workStatus);
            var saved = await _tmanagementDbase.SaveChangesAsync();
            return saved > 0? true : false;
        }

        public async Task<bool> WorkExist(int workId)
        {
            var workE = await _tmanagementDbase.workItems.FindAsync(workId);
            if(workE == null)
            {
                return false;
            }
            return true;
        }

    }
}