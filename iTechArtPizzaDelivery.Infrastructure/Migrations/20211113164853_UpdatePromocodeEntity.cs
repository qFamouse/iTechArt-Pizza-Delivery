using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaDelivery.Infrastructure.Migrations
{
    public partial class UpdatePromocodeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Promocodes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Promocodes");
        }
    }
}
