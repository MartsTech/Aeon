using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Ratings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9fae5394-bb21-446b-80b9-c3ed55bc1f51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c15cc235-1596-46d3-b91b-8d66d0e0e715"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dcf394e6-5c38-4e32-8192-f2d0982a76bd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f69acb2a-06cd-40ac-907c-df9d348f6c82"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3933bc2a-8aa8-4e61-b383-db72679c2547"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("402af308-a6b0-4574-acf5-dc3d57d3cad9"));

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6add9014-ce94-4bdb-9755-960586362474"), "Vegetables" },
                    { new Guid("9966870c-9dc8-483e-b64c-a5f88b3030c2"), "Fruits" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("20e33b06-18da-4685-8b54-e282072e2be9"), new Guid("9966870c-9dc8-483e-b64c-a5f88b3030c2"), "Orange fruit", 0m, "", 2m, 2, "Orange" },
                    { new Guid("69e1eb16-1f07-4ee4-9607-3b12af7fd09d"), new Guid("6add9014-ce94-4bdb-9755-960586362474"), "Red vegetable", 0m, "", 1m, 6, "Tomato" },
                    { new Guid("7b72248b-7176-4e12-b9b1-6bd8cd6395fc"), new Guid("6add9014-ce94-4bdb-9755-960586362474"), "Green vegetable", 0m, "", 4m, 1, "Cucumber" },
                    { new Guid("a228e017-1770-4fde-abe3-699e015ad74b"), new Guid("9966870c-9dc8-483e-b64c-a5f88b3030c2"), "Red fruit", 0m, "", 3m, 3, "Apple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("20e33b06-18da-4685-8b54-e282072e2be9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69e1eb16-1f07-4ee4-9607-3b12af7fd09d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b72248b-7176-4e12-b9b1-6bd8cd6395fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a228e017-1770-4fde-abe3-699e015ad74b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6add9014-ce94-4bdb-9755-960586362474"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9966870c-9dc8-483e-b64c-a5f88b3030c2"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3933bc2a-8aa8-4e61-b383-db72679c2547"), "Vegetables" },
                    { new Guid("402af308-a6b0-4574-acf5-dc3d57d3cad9"), "Fruits" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("9fae5394-bb21-446b-80b9-c3ed55bc1f51"), new Guid("3933bc2a-8aa8-4e61-b383-db72679c2547"), "Green vegetable", 0m, "", 4m, 1, "Cucumber" },
                    { new Guid("c15cc235-1596-46d3-b91b-8d66d0e0e715"), new Guid("402af308-a6b0-4574-acf5-dc3d57d3cad9"), "Orange fruit", 0m, "", 2m, 2, "Orange" },
                    { new Guid("dcf394e6-5c38-4e32-8192-f2d0982a76bd"), new Guid("3933bc2a-8aa8-4e61-b383-db72679c2547"), "Red vegetable", 0m, "", 1m, 6, "Tomato" },
                    { new Guid("f69acb2a-06cd-40ac-907c-df9d348f6c82"), new Guid("402af308-a6b0-4574-acf5-dc3d57d3cad9"), "Red fruit", 0m, "", 3m, 3, "Apple" }
                });
        }
    }
}
