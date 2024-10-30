using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClothesPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Clothes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Clothes",
                type: "decimal(10,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
