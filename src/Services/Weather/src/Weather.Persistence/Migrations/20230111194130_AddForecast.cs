using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Weather.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TemperatureC = table.Column<int>(type: "INTEGER", maxLength: 3, nullable: false),
                    Summary = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("2e462234-1e19-4a00-ba6b-e49930c571a6"), new DateOnly(2023, 1, 12), "Sweltering", -8 },
                    { new Guid("384272b5-1a6f-4aaf-8c5c-2628f73dfd49"), new DateOnly(2023, 1, 14), "Bracing", 39 },
                    { new Guid("ab8db0e2-ae0a-4657-98b7-4beb9cb37bf1"), new DateOnly(2023, 1, 16), "Cool", -9 },
                    { new Guid("b46b2c2b-90a3-423e-b59e-79e084ac25ab"), new DateOnly(2023, 1, 15), "Chilly", 42 },
                    { new Guid("c08dda04-c47f-4879-ba77-66ae6ed3a4c1"), new DateOnly(2023, 1, 13), "Mild", 32 }
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
