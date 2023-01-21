using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("456a79b0-f3db-413e-a850-84b1fbf44f98"), "Vegetables" },
                    { new Guid("cdd09831-7b35-4778-9e4b-fcbacb570d46"), "Fruits" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("135b684e-8f74-4c9b-9177-e4ea50b68605"), new Guid("456a79b0-f3db-413e-a850-84b1fbf44f98"), "Green vegetable", 0m, "", 4m, 1, "Cucumber" },
                    { new Guid("584cae8d-89d6-48c9-ad33-89dc47190388"), new Guid("cdd09831-7b35-4778-9e4b-fcbacb570d46"), "Orange fruit", 0m, "", 2m, 2, "Orange" },
                    { new Guid("b3a22697-9f71-4b6a-9cae-667f415cbd6c"), new Guid("cdd09831-7b35-4778-9e4b-fcbacb570d46"), "Red fruit", 0m, "", 3m, 3, "Apple" },
                    { new Guid("ca4ff4bb-f52f-4669-a4ff-a8c1d1101b7f"), new Guid("456a79b0-f3db-413e-a850-84b1fbf44f98"), "Red vegetable", 0m, "", 1m, 6, "Tomato" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
