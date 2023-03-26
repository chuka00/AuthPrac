using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthPrac.Migrations
{
    public partial class Updateproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vendors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Vendors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customers",
                newName: "Name");
        }
    }
}
