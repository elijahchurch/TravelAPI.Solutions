using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "CityName", "Country", "Rating", "Review" },
                values: new object[,]
                {
                    { 1, "Bend", "United States", 9, "Nice sunny vaction spot" },
                    { 2, "Sayulita", "Mexico", 8, "Surf vacation spot" },
                    { 3, "Osaka", "Japan", 10, "Great place to see Japanese food spots and culture" },
                    { 4, "Alicante", "Spain", 8, "Good food and great flamenco" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 4);
        }
    }
}
