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
        //private readonly UserManager<UserModel> _userManager;
        public UserRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var userEmail = await _dbContext.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
            return userEmail;
        }

        public async Task<ICollection<UserModel>> GetUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<UserModel> DeleteUser(string email)
        {
            var user =  await _dbContext.Users.Where(u=> u.Email == email).FirstOrDefaultAsync();
            if(user!= null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
            return user;


        }

        // public async Task<ICollection<WorkItem>> GetWorkItems()
        // {
        //     var workItems = await _dbContext.Users
        //     .Include(u => u.WorkItems)
        //     .ToListAsync();
        //     return workItems.SelectMany(u => u.WorkItems).ToList();
        // }}

    }

}