using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02ea6906-3464-44b0-8280-b5057671b575"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58e71a71-8f85-4c8d-bcac-3430e43e7413"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65af12f2-82c9-45d4-8b27-d160f70a6ae2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9ee2fad3-5579-4e97-82e6-81d6e0afb702"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Content = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Upvotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CommentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upvotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upvotes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Upvotes_CommentId",
                table: "Upvotes",
                column: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Upvotes");

            migrationBuilder.DropTable(
                name: "Comments");

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"), "Fruits" },
                    { new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"), "Vegetables" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("02ea6906-3464-44b0-8280-b5057671b575"), new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"), "Orange fruit", 0m, "", 2m, 2, "Orange" },
                    { new Guid("58e71a71-8f85-4c8d-bcac-3430e43e7413"), new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"), "Red fruit", 0m, "", 3m, 3, "Apple" },
                    { new Guid("65af12f2-82c9-45d4-8b27-d160f70a6ae2"), new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"), "Green vegetable", 0m, "", 4m, 1, "Cucumber" },
                    { new Guid("9ee2fad3-5579-4e97-82e6-81d6e0afb702"), new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"), "Red vegetable", 0m, "", 1m, 6, "Tomato" }
                });
        }
    }
}
