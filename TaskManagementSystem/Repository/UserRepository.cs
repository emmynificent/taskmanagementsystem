using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repository
{
    public class UserRepository : IUserModel
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly UserManager<UserModel> _userManager;
        public UserRepository(TaskManagementDbContext dbContext, UserManager<UserModel> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> GetUserModel(int Id)
        {
            var user = await _dbContext.Users.FindAsync(Id);
            return user;
        }

        public async Task<ICollection<UserModel>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<ICollection<WorkItem>> GetWorkItems()
        {
            var workItems = await _dbContext.Users
            .Include(u => u.WorkItems)
            .ToListAsync();
            return workItems.SelectMany(u => u.WorkItems).ToList();
        }
    }

}