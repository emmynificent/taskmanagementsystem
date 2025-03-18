using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class onDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_userModels_UserId",
                        column: x => x.UserId,
                        principalTable: "userModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedUserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workItems_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workItems_userModels_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "userModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auditLogModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditLogModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_auditLogModels_userModels_UserId",
                        column: x => x.UserId,
                        principalTable: "userModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_auditLogModels_workItems_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "workItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_userModels_UserId",
                        column: x => x.UserId,
                        principalTable: "userModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comments_workItems_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "workItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "Id", "ProjectName" },
                values: new object[,]
                {
                    { 1, "Task Management System" },
                    { 2, "E-commerce Platform" }
                });

            migrationBuilder.InsertData(
                table: "userModels",
                columns: new[] { "Id", "Created", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", "John Doe" },
                    { 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "Id", "IsRead", "NoticeCreated", "NoticeMessage", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task assigned to you", 1 },
                    { 2, false, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "New comment on your task", 2 }
                });

            migrationBuilder.InsertData(
                table: "workItems",
                columns: new[] { "Id", "AssignedUserId", "Description", "DueDate", "ProjectId", "Title", "status" },
                values: new object[,]
                {
                    { 1, 1, "Create ERD for the project", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Design Database", 2 },
                    { 2, 2, "Build backend API", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Develop API", 0 }
                });

            migrationBuilder.InsertData(
                table: "auditLogModels",
                columns: new[] { "Id", "Action", "TimeStamp", "UserId", "WorkItemId" },
                values: new object[,]
                {
                    { 1, "Created Task", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, "Updated Task", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "Id", "Created", "Text", "UserId", "WorkItemId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great work!", 2, 1 },
                    { 2, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Need some modifications", 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_auditLogModels_UserId",
                table: "auditLogModels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_auditLogModels_WorkItemId",
                table: "auditLogModels",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_WorkItemId",
                table: "comments",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_UserId",
                table: "notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_workItems_AssignedUserId",
                table: "workItems",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_workItems_ProjectId",
                table: "workItems",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auditLogModels");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "workItems");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "userModels");
        }
    }
}
