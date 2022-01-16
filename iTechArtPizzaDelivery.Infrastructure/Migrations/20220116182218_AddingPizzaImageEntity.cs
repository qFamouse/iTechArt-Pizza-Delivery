using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaDelivery.Infrastructure.Migrations
{
    public partial class AddingPizzaImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Pizzas_PizzaId",
                table: "PizzasSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Sizes_SizeId",
                table: "PizzasSizes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "PizzasSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PizzaId",
                table: "PizzasSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaImageId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaImages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaImageId",
                table: "Pizzas",
                column: "PizzaImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaImages_PizzaImageId",
                table: "Pizzas",
                column: "PizzaImageId",
                principalTable: "PizzaImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzasSizes_Pizzas_PizzaId",
                table: "PizzasSizes",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzasSizes_Sizes_SizeId",
                table: "PizzasSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaImages_PizzaImageId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Pizzas_PizzaId",
                table: "PizzasSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Sizes_SizeId",
                table: "PizzasSizes");

            migrationBuilder.DropTable(
                name: "PizzaImages");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaImageId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaImageId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "PizzasSizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaId",
                table: "PizzasSizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzasSizes_Pizzas_PizzaId",
                table: "PizzasSizes",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzasSizes_Sizes_SizeId",
                table: "PizzasSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
