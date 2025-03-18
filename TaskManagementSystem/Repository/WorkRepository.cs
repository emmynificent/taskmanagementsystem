using System.Data.Entity.Core.Common.EntitySql;
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
            await _tmanagementDbase.AddAsync(workItem);
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
            
            _tmanagementDbase.Update(existingworkItem);
            var saved = await _tmanagementDbase.SaveChangesAsync();
            return saved > 0 ? true : false;

        }
    }
}