using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interface
{
    public interface IUserModel
    {
        Task<ICollection<UserModel>> GetUsersAsync();
        Task<UserModel> CreateUserAsync(UserModel user);
        //Task<ICollection<WorkItem>> GetWorkItems();
        Task<UserModel> GetUserByEmail(string UserEmail);
        Task<UserModel> DeleteUser(string UserEmail);

    }
}
