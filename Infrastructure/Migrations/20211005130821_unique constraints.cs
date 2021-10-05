using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class uniqueconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LocationSize_SizeName",
                table: "LocationSize",
                column: "SizeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Column_Row_StoreId",
                table: "Locations",
                columns: new[] { "Column", "Row", "StoreId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocationSize_SizeName",
                table: "LocationSize");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Column_Row_StoreId",
                table: "Locations");
        }
    }
}
