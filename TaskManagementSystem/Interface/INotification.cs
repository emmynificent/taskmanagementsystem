using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interface
{
    public interface INotification
    {
        Task <ICollection<Notification>> GetNotifications();
        Task <Notification> CreateNotificationAsync(Notification notification);
        Task <bool> UpdateNotificationStatus(Notification notificationStatus);
        Task<Notification> GetNotification(int Id);
    

    }
}