using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class LocationSizeTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "height",
                table: "LocationSize",
                newName: "Height");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "LocationSize",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "LocationSize",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LocationSize",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "LocationSize",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "LocationSize",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "LocationSize");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "LocationSize");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LocationSize");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "LocationSize");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "LocationSize");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "LocationSize",
                newName: "height");
        }
    }
}
