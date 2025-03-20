using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public class TaskManagementDbContext: DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base (options)
        {

        }
        public DbSet<UserModel> userModels {get; set;}
        public DbSet<WorkItem> workItems {get; set;}
        public DbSet<Project> projects {get; set;}
        public DbSet<Notification> notifications{get; set;}
        public DbSet<Comment> comments{get; set;}
        public DbSet<AuditLogModel> auditLogModels{get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuditLogModel>()
        .HasOne(a => a.WorkItem)
        .WithMany()
        .HasForeignKey(a => a.WorkItemId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AuditLogModel>()
        .HasOne(a => a.User)
        .WithMany()
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Comment>()
        .HasOne(c => c.WorkItem)
        .WithMany(w => w.comments)
        .HasForeignKey(c => c.WorkItemId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
        .HasOne(w => w.User)
        .WithMany()
        .HasForeignKey(w => w.UserId)
        .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<WorkItem>()
        .HasOne(w => w.Project)
        .WithMany(p => p.WorkItems)
        .HasForeignKey(w => w.projectId)
        .OnDelete(DeleteBehavior.Cascade);
        

          modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, FullName = "John Doe", Email = "john@example.com", Created = new DateTime(2025, 3, 15) },
                new UserModel { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", Created = new DateTime(2025, 3, 15)}
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProjectName = "Task Management System" },
                new Project { Id = 2, ProjectName = "E-commerce Platform" },
                new Project { Id = 3, ProjectName = "AI-Integration"}
            );

            modelBuilder.Entity<WorkItem>().HasData(
                new WorkItem { Id = 1, Title = "Design Database", Description = "Create ERD for the project", status = Status.InProgress, DueDate = new DateTime(2025, 3, 15), AssignedUserId = 1 },
                new WorkItem { Id = 2, Title = "Develop API", Description = "Build backend API", status = Status.New, DueDate = new DateTime(2025, 3, 15), AssignedUserId = 2 }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Text = "Great work!", Created = new DateTime(2025, 3, 15), WorkItemId = 1, UserId = 2 },
                new Comment { Id = 2, Text = "Need some modifications", Created = new DateTime(2025, 3, 15), WorkItemId = 2, UserId = 1 }
            );

            modelBuilder.Entity<AuditLogModel>().HasData(
                new AuditLogModel { Id = 1, Action = "Created Task", TimeStamp =new DateTime(2025, 3, 15), UserId = 1, WorkItemId = 1 },
                new AuditLogModel { Id = 2, Action = "Updated Task", TimeStamp = new DateTime(2025, 3, 15), UserId = 2, WorkItemId = 2 }
            );

            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, NoticeMessage = "Task assigned to you", NoticeCreated = new DateTime(2025, 3, 15), IsRead = false, UserId = 1 },
                new Notification { Id = 2, NoticeMessage = "New comment on your task", NoticeCreated = new DateTime(2025, 3, 15), IsRead = false, UserId = 2 }
            );

    }


    }

}