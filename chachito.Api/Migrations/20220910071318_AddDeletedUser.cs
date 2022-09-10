using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chachito.Api.Migrations
{
    public partial class AddDeletedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "User");
        }
    }
}
