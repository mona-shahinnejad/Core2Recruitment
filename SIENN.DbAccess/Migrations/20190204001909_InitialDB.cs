using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIENN.DbAccess.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Acronym = table.Column<string>(maxLength: 5, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    ModifyDateTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    DeliveryDateTime = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<long>(nullable: false),
                    UnitId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreateDateTime", "IsActive", "ModifyDateTime", "Name" },
                values: new object[,]
                {
                    { 1L, "C0001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "House Stuff" },
                    { 2L, "C0002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kitchen Stuff" },
                    { 3L, "C0003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronic & Computer" },
                    { 4L, "C0004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Stuff" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Code", "CreateDateTime", "ModifyDateTime", "Name" },
                values: new object[,]
                {
                    { 1L, "PT0001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cooking Stuff" },
                    { 2L, "PT0002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sleeping Stuff" },
                    { 3L, "PT0003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car Accessories" },
                    { 4L, "PT0004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile" },
                    { 5L, "PT0005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Watche" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Acronym", "Code", "CreateDateTime", "Description", "ModifyDateTime", "Name" },
                values: new object[,]
                {
                    { 1L, "pc", "U0001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Normal piece of products", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piece" },
                    { 2L, "b", "U0002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Normal box of products,contains 6 pieces", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Box" },
                    { 3L, "m", "U0003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Code",
                table: "ProductTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Acronym",
                table: "Units",
                column: "Acronym",
                unique: true,
                filter: "[Acronym] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Code",
                table: "Units",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
