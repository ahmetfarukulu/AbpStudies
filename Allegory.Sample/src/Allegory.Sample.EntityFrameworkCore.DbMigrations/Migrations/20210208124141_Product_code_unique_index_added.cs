using Microsoft.EntityFrameworkCore.Migrations;

namespace Allegory.Sample.Migrations
{
    public partial class Product_code_unique_index_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppProducts_Code",
                table: "AppProducts");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_Code",
                table: "AppProducts",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppProducts_Code",
                table: "AppProducts");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_Code",
                table: "AppProducts",
                column: "Code");
        }
    }
}
