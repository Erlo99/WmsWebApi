using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UserStoresTableWithForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserStores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserStores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "UserStores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "UserStores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStores_StoreId",
                table: "UserStores",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStores_Stores_StoreId",
                table: "UserStores",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStores_Users_UserId",
                table: "UserStores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStores_Stores_StoreId",
                table: "UserStores");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStores_Users_UserId",
                table: "UserStores");

            migrationBuilder.DropIndex(
                name: "IX_UserStores_StoreId",
                table: "UserStores");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserStores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserStores");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "UserStores");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UserStores");
        }
    }
}
