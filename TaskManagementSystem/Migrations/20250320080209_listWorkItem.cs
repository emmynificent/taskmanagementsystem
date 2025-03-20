using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class listWorkItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workItems_projects_projectId",
                table: "workItems");

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "Id", "ProjectName" },
                values: new object[] { 3, "AI-Integration" });

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_projects_projectId",
                table: "workItems",
                column: "projectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workItems_projects_projectId",
                table: "workItems");

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_projects_projectId",
                table: "workItems",
                column: "projectId",
                principalTable: "projects",
                principalColumn: "Id");
        }
    }
}
