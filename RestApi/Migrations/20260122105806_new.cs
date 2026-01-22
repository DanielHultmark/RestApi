using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonIntrests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IntrestId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonIntrests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonIntrests_Intrests_IntrestId",
                        column: x => x.IntrestId,
                        principalTable: "Intrests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonIntrests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Intrests",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Att ta och redigera bilder.", "Fotografi" },
                    { 2, "Träning och tävling inom långdistans.", "Löpning" },
                    { 3, "Experimentera med recept och råvaror.", "Matlagning" },
                    { 4, "Spela spel på PC och konsol.", "Gaming" },
                    { 5, "Utforska nya platser och kulturer.", "Resor" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNr" },
                values: new object[,]
                {
                    { 1, "anna.svensson@example.com", "Anna", "Svensson", "0701234567" },
                    { 2, "johan.lindberg@example.com", "Johan", "Lindberg", "0739876543" },
                    { 3, "sara.ekstrom@example.com", "Sara", "Ekström", "0765551122" },
                    { 4, "daniel.hultmark@example.com", "Daniel", "Hultmark", "0707654321" },
                    { 5, "mikael.berg@example.com", "Mikael", "Berg", "0729988776" }
                });

            migrationBuilder.InsertData(
                table: "PersonIntrests",
                columns: new[] { "Id", "IntrestId", "Link", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, "https://instagram.com/anna_photography", 1 },
                    { 2, 3, "https://anna-cooks.example.com", 1 },
                    { 3, 2, "https://strava.com/johan_runs", 2 },
                    { 4, 5, "https://travelwithsara.example.com", 3 },
                    { 5, 4, "https://steamcommunity.com/id/danielh", 4 },
                    { 6, 1, "https://flickr.com/mikael_berg", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonIntrests_IntrestId",
                table: "PersonIntrests",
                column: "IntrestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonIntrests_PersonId",
                table: "PersonIntrests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonIntrests");

            migrationBuilder.DeleteData(
                table: "Intrests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Intrests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Intrests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Intrests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Intrests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
