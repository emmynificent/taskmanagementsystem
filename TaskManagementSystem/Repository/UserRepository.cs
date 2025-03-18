using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repository
{
    public class UserRepository: IUserModel
    {
        private readonly TaskManagementDbContext _dbContext;
        public UserRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            await _dbContext.userModels.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public  async Task<UserModel> GetUserModel(int Id)
        {
            var user = await _dbContext.userModels.FindAsync(Id);
            return user;
        }

        public async Task<ICollection<UserModel>> GetUsers()
        {
            var users = await _dbContext.userModels.ToListAsync();
            return users;
        }

        public async Task<ICollection<WorkItem>> GetWorkItems()
        {
            var workItems = await _dbContext.userModels
            .Include(u => u.WorkItems)
            .ToListAsync();
            return workItems.SelectMany(u => u.WorkItems).ToList();
        }

        
    }
    
}