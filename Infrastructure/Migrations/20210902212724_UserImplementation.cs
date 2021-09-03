using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UserImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(name: "Identifier", table: "Questions", newName: "ChangedIdentifier", schema: "dbo");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChangedIdentifier",
                table: "Roles",
                column: "ChangedIdentifier",
                unique: true,
                filter: "[ChangedIdentifier] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
               name: "IX_Questions_Identifier",
               table: "Questions");
        }
    }
}
