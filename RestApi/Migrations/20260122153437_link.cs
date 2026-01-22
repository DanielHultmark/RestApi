using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "PersonIntrests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "PersonIntrests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PersonIntrests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: "https://instagram.com/anna_photography");

            migrationBuilder.UpdateData(
                table: "PersonIntrests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Link",
                value: "https://anna-cooks.example.com");

            migrationBuilder.UpdateData(
                table: "PersonIntrests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Link",
                value: "https://strava.com/johan_runs");

            migrationBuilder.UpdateData(
                table: "PersonIntrests",
                keyColumn: "Id",
                keyValue: 4,
                column: "Link",
                value: "https://travelwithsara.example.com");

            migrationBuilder.UpdateData(
                table: "PersonIntrests",
                keyColumn: "Id",
                keyValue: 5,
                column: "Link",
                value: "https://steamcommunity.com/id/danielh");

            migrationBuilder.UpdateData(
                table: "PersonIntrests",
                keyColumn: "Id",
                keyValue: 6,
                column: "Link",
                value: "https://flickr.com/mikael_berg");
        }
    }
}
