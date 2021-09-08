using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class LocationCargosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Locations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationCargos_Cargos_Barcode",
                        column: x => x.Barcode,
                        principalTable: "Cargos",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationCargos_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_LocationId",
                table: "UserOperations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperations_UserId",
                table: "UserOperations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationCargos_Barcode",
                table: "LocationCargos",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_LocationCargos_LocationId",
                table: "LocationCargos",
                column: "LocationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperations_Locations_LocationId",
                table: "UserOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperations_Users_UserId",
                table: "UserOperations");

            migrationBuilder.DropTable(
                name: "LocationCargos");

            migrationBuilder.DropIndex(
                name: "IX_UserOperations_LocationId",
                table: "UserOperations");

            migrationBuilder.DropIndex(
                name: "IX_UserOperations_UserId",
                table: "UserOperations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Locations");
        }
    }
}
