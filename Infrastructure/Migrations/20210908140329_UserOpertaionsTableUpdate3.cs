using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UserOpertaionsTableUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperations_Locations_LocationId",
                table: "UserOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperations_Users_UserId",
                table: "UserOperations");

            migrationBuilder.DropIndex(
                name: "IX_UserOperations_LocationId",
                table: "UserOperations");

            migrationBuilder.DropIndex(
                name: "IX_UserOperations_UserId",
                table: "UserOperations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "UserOperations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserOperations");

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "UserOperations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "UserOperations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserOperations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "UserOperations");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserOperations");

            migrationBuilder.AlterColumn<int>(
                name: "StoreName",
                table: "UserOperations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "UserOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_LocationId",
                table: "UserOperations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_UserId",
                table: "UserOperations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperations_Locations_LocationId",
                table: "UserOperations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperations_Users_UserId",
                table: "UserOperations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
