using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi06_EFCore_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNameHangHoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoas_Loai_MaLoai",
                table: "HangHoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas");

            migrationBuilder.RenameTable(
                name: "HangHoas",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_HangHoas_MaLoai",
                table: "Product",
                newName: "IX_Product_MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "MaHh");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Loai_MaLoai",
                table: "Product",
                column: "MaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Loai_MaLoai",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "HangHoas");

            migrationBuilder.RenameIndex(
                name: "IX_Product_MaLoai",
                table: "HangHoas",
                newName: "IX_HangHoas_MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangHoas",
                table: "HangHoas",
                column: "MaHh");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoas_Loai_MaLoai",
                table: "HangHoas",
                column: "MaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai");
        }
    }
}
