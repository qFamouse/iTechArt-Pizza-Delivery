using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaDelivery.Infrastructure.Migrations
{
    public partial class AddPizzaIngredientIdProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_PizzasSizes_PizzaSizeId",
                table: "PizzaIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaSizeId",
                table: "PizzaIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "PizzaIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_PizzasSizes_PizzaSizeId",
                table: "PizzaIngredients",
                column: "PizzaSizeId",
                principalTable: "PizzasSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredients_PizzasSizes_PizzaSizeId",
                table: "PizzaIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaSizeId",
                table: "PizzaIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "PizzaIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_Ingredients_IngredientId",
                table: "PizzaIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredients_PizzasSizes_PizzaSizeId",
                table: "PizzaIngredients",
                column: "PizzaSizeId",
                principalTable: "PizzasSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
