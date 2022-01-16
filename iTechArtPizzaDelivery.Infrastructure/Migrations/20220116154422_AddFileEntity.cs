using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArtPizzaDelivery.Infrastructure.Migrations
{
    public partial class AddFileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Pizzas_PizzaId",
                table: "PizzasSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Sizes_SizeId",
                table: "PizzasSizes");

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

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<short>(type: "smallint", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

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
                name: "FK_PizzasSizes_Pizzas_PizzaId",
                table: "PizzasSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzasSizes_Sizes_SizeId",
                table: "PizzasSizes");

            migrationBuilder.DropTable(
                name: "Files");

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
