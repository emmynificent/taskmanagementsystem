using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workItems_userModels_AssignedUserId",
                table: "workItems");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedUserId",
                table: "workItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_userModels_AssignedUserId",
                table: "workItems",
                column: "AssignedUserId",
                principalTable: "userModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workItems_userModels_AssignedUserId",
                table: "workItems");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedUserId",
                table: "workItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_workItems_userModels_AssignedUserId",
                table: "workItems",
                column: "AssignedUserId",
                principalTable: "userModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
