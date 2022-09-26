using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimsAPI.Migrations
{
    public partial class IsMuertoadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMuerto",
                table: "Sims",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMuerto",
                table: "Sims");
        }
    }
}
