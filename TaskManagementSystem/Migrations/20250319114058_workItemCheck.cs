using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class workItemCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workItems_projects_ProjectId",
                table: "workItems");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "workItems",
                newName: "projectId");

            migrationBuilder.RenameIndex(
                name: "IX_workItems_ProjectId",
                table: "workItems",
                newName: "IX_workItems_projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_projects_projectId",
                table: "workItems",
                column: "projectId",
                principalTable: "projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workItems_projects_projectId",
                table: "workItems");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "workItems",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_workItems_projectId",
                table: "workItems",
                newName: "IX_workItems_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_projects_ProjectId",
                table: "workItems",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id");
        }
    }
}
