using Microsoft.EntityFrameworkCore.Migrations;

namespace MatikoWebAppProject.Migrations
{
    public partial class includingAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Users",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Users",
                newName: "type");
        }
    }
}
