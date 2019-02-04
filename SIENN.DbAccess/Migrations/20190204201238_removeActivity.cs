using Microsoft.EntityFrameworkCore.Migrations;

namespace SIENN.DbAccess.Migrations
{
    public partial class removeActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Code",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Categories",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Code",
                table: "Categories");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Categories",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
