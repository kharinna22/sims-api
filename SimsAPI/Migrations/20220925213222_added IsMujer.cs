using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimsAPI.Migrations
{
    public partial class addedIsMujer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMujer",
                table: "Sims",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMujer",
                table: "Sims");
        }
    }
}
