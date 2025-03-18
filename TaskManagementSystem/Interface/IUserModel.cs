using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interface
{
    public interface IUserModel
    {
        Task<ICollection<UserModel>> GetUsers();
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<ICollection<WorkItem>> GetWorkItems();
        Task<UserModel> GetUserModel(int Id);

    }
}
