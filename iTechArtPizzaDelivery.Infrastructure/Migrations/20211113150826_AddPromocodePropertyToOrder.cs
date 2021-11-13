using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaDelivery.Infrastructure.Migrations
{
    public partial class AddPromocodePropertyToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocodeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders",
                column: "PromocodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Promocodes_PromocodeId",
                table: "Orders",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Promocodes_PromocodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PromocodeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PromocodeId",
                table: "Orders");
        }
    }
}
