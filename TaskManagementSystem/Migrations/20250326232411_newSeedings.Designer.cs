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
    [Migration("20250326232411_newSeedings")]
    partial class newSeedings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

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
                            Created = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Text = "Great work!",
                            UserId = "2",
                            WorkItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Text = "Need some modifications",
                            UserId = "1",
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("notifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsRead = false,
                            NoticeCreated = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            NoticeMessage = "Task assigned to you",
                            UserId = "1"
                        },
                        new
                        {
                            Id = 2,
                            IsRead = false,
                            NoticeCreated = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            NoticeMessage = "New comment on your task",
                            UserId = "2"
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
                        },
                        new
                        {
                            Id = 3,
                            ProjectName = "AI-Integration"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "44906c45-0dfb-43b3-a210-297d562bc35b",
                            Created = new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "fmlzur@gmail.com",
                            EmailConfirmed = true,
                            FullName = "Fem Lanz",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEPcESYX3lWBJknNMPPr2A24EXCDULY51GRImjr4nZz6DRIAfFGpPunJtMqKyM6dt",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b55707ca-c22e-47c6-94aa-2cea529480b5",
                            TwoFactorEnabled = false,
                            UserName = "fmlzur@gmail.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b306dc41-dfe9-459c-9bc3-4feb62cfbfab",
                            Created = new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "stevejobs@gmail.com",
                            EmailConfirmed = true,
                            FullName = "Steve Jobs",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAELOyIdlI0ROGnZezdYeBR5llcJv4xUEO5qGXmLSp0GuBkIhaswBtXyzsLKxAArlv4w",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9c429c9f-94ce-4cc5-8114-7998d4d1dfed",
                            TwoFactorEnabled = false,
                            UserName = "stevejobs@gmail.com"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Models.WorkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssignedUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("projectId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("projectId");

                    b.ToTable("workItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedUserId = "1",
                            Description = "Create ERD for the project",
                            DueDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Title = "Design Database",
                            projectId = 1,
                            status = 2
                        },
                        new
                        {
                            Id = 2,
                            AssignedUserId = "2",
                            Description = "Build backend API",
                            DueDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Title = "Develop API",
                            projectId = 2,
                            status = 0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.HasOne("TaskManagementSystem.Models.Project", "Project")
                        .WithMany("WorkItems")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AssignedUser");

                    b.Navigation("Project");
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
