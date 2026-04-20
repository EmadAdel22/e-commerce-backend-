using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_UserId",
                table: "products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_UserId",
                table: "products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_UserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_UserId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "products");
        }
    }
}
