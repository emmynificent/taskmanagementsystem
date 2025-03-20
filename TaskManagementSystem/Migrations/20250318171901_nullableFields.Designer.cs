﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Data;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    [DbContext(typeof(TaskManagementDbContext))]
    [Migration("20250318171901_nullableFields")]
    partial class nullableFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagementSystem.Models.AuditLogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("auditLogModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = "Created Task",
                            TimeStamp = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WorkItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Action = "Updated Task",
                            TimeStamp = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            WorkItemId = 2
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Great work!",
                            UserId = 2,
                            WorkItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Need some modifications",
                            UserId = 1,
                            WorkItemId = 2
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NoticeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoticeMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("notifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsRead = false,
                            NoticeCreated = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoticeMessage = "Task assigned to you",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsRead = false,
                            NoticeCreated = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoticeMessage = "New comment on your task",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectName = "Task Management System"
                        },
                        new
                        {
                            Id = 2,
                            ProjectName = "E-commerce Platform"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("userModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@example.com",
                            FullName = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane@example.com",
                            FullName = "Jane Smith"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.WorkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("workItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedUserId = 1,
                            Description = "Create ERD for the project",
                            DueDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Design Database",
                            status = 2
                        },
                        new
                        {
                            Id = 2,
                            AssignedUserId = 2,
                            Description = "Build backend API",
                            DueDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Develop API",
                            status = 0
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.AuditLogModel", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagementSystem.Models.WorkItem", "WorkItem")
                        .WithMany()
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Comment", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagementSystem.Models.WorkItem", "WorkItem")
                        .WithMany("comments")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Notification", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.WorkItem", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", "AssignedUser")
                        .WithMany("WorkItems")
                        .HasForeignKey("AssignedUserId");

                    b.HasOne("TaskManagementSystem.Models.Project", null)
                        .WithMany("WorkItems")
                        .HasForeignKey("ProjectId");

                    b.Navigation("AssignedUser");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Project", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.UserModel", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.WorkItem", b =>
                {
                    b.Navigation("comments");
                });
#pragma warning restore 612, 618
        }
    }
}
