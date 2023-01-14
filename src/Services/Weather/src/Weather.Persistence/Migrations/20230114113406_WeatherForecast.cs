using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Weather.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WeatherForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Summary = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("1ea6663f-419d-4950-97c9-8fb635fc2e41"), new DateTime(2023, 1, 16, 13, 34, 6, 705, DateTimeKind.Local).AddTicks(1784), "Cool", 47 },
                    { new Guid("2b95893a-071a-4a49-b26d-4f6dacfa0bf3"), new DateTime(2023, 1, 18, 13, 34, 6, 705, DateTimeKind.Local).AddTicks(1794), "Chilly", 38 },
                    { new Guid("74d254ab-f943-43a1-b07f-7565b966fed8"), new DateTime(2023, 1, 19, 13, 34, 6, 705, DateTimeKind.Local).AddTicks(1798), "Chilly", 49 },
                    { new Guid("d54e2ca2-3187-4e31-a46d-5d9b8b94cf54"), new DateTime(2023, 1, 17, 13, 34, 6, 705, DateTimeKind.Local).AddTicks(1789), "Chilly", -14 },
                    { new Guid("fa06f8db-ca63-4922-8e00-18b18d2089ea"), new DateTime(2023, 1, 15, 13, 34, 6, 705, DateTimeKind.Local).AddTicks(1678), "Hot", 49 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
