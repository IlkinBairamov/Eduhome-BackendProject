using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendProject.Migrations
{
    public partial class UpdateUserTableSubscribeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Subscribe",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscribe",
                table: "AspNetUsers");
        }
    }
}
