using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public class TaskManagementDbContext:IdentityDbContext<UserModel>
     {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base (options)
        {

        }
       // public DbSet<UserModel> userModels {get; set;}
        public DbSet<WorkItem> workItems {get; set;}
        public DbSet<Project> projects {get; set;}
        public DbSet<Notification> notifications{get; set;}
        public DbSet<Comment> comments{get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var user1 = new UserModel
        {
            Id = "1",
            UserName = "fmlzur@gmail.com",
            FullName = "Fem Lanz",
            Email = "fmlzur@gmail.com",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEPcESYX3lWBJknNMPPr2A24EXCDULY51GRImjr4nZz6DRIAfFGpPunJtMqKyM6dt",
            Created = new DateTime(2025, 3, 11, 0, 0, 0, DateTimeKind.Utc)

        };

        var user2 = new UserModel
        {
            Id = "2",
            UserName = "stevejobs@gmail.com",
            FullName = "Steve Jobs",
            Email = "stevejobs@gmail.com",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAELOyIdlI0ROGnZezdYeBR5llcJv4xUEO5qGXmLSp0GuBkIhaswBtXyzsLKxAArlv4w",
            Created = new DateTime(2025, 3, 11, 0, 0, 0, DateTimeKind.Utc)
        };
        

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
        

        modelBuilder.Entity<UserModel>().HasData(user1, user2);

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, ProjectName = "Task Management System" },
            new Project { Id = 2, ProjectName = "E-commerce Platform" },
            new Project { Id = 3, ProjectName = "AI-Integration"}
        );

        modelBuilder.Entity<WorkItem>().HasData(
            new WorkItem {
                Id = 1,
                Title = "Design Database",
                Description = "Create ERD for the project",
                status = Status.InProgress,
                DueDate = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                AssignedUserId = "1",
                projectId = 1
                
                },
            new WorkItem {
                Id = 2,
                Title = "Develop API",
                Description = "Build backend API",
                status = Status.New,
                DueDate = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                AssignedUserId = "2" ,
                projectId = 2
                
                }
        );

        modelBuilder.Entity<Comment>().HasData(
            new Comment { 
                Id = 1,
                Text = "Great work!",
                Created = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc),
                WorkItemId = 1,
                UserId = "2"
                },
            new Comment {
                Id = 2, 
                Text = "Need some modifications", 
                Created = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc), 
                WorkItemId = 2, 
                UserId = "1"
                
                }
        );

        modelBuilder.Entity<Notification>().HasData(
            new Notification { 
                Id = 1, 
                NoticeMessage = "Task assigned to you", 
                NoticeCreated = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc), 
                IsRead = false, 
                UserId = "1" 
                },
            new Notification { 
                Id = 2, 
                NoticeMessage = "New comment on your task", 
                NoticeCreated = new DateTime(2025, 3, 15,0, 0, 0, DateTimeKind.Utc), 
                IsRead = false, 
                UserId = "2" 
                }
        );

        }
        
           
     }

}