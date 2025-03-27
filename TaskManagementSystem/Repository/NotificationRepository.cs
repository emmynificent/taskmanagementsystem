using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interface;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repository
{
    public class NotificationRepository : INotification
    {
        private readonly TaskManagementDbContext _dbContext;

        public NotificationRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notification> CreateNotificationAsync(Notification notification)
        {
            await _dbContext.notifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
            return notification;
        }

        public async Task<ICollection<Notification>> GetNotifications()
        {
            var notifications = await _dbContext.notifications.ToListAsync();
            return notifications;
        }

        public async Task<bool> UpdateNotificationStatus(Notification notificationStatus)
        {
            _dbContext.notifications.Update(notificationStatus);
            var status =await _dbContext.SaveChangesAsync();
            return status > 0? true : false;
        }

        public async Task<Notification> GetNotification(int Id)
        {
            var notification = await _dbContext.notifications.Where(n => n.Id == Id)
            .FirstOrDefaultAsync();
            return notification;
        }
    }
}