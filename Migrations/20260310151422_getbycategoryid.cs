using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    /// <inheritdoc />
    public partial class getbycategoryid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_categoryId",
                table: "products",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Categories_categoryId",
                table: "products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Categories_categoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_categoryId",
                table: "products");
        }
    }
}
