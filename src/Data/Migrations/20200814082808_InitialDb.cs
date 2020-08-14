using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VueClassValidation.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TicketScalper");

            migrationBuilder.CreateTable(
                name: "Acts",
                schema: "TicketScalper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                schema: "TicketScalper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Address_Address1 = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
                    Address_Address2 = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
                    Address_Address3 = table.Column<string>(maxLength: 100, nullable: true, defaultValue: ""),
                    Address_CityTown = table.Column<string>(maxLength: 50, nullable: true, defaultValue: ""),
                    Address_StateProvince = table.Column<string>(maxLength: 50, nullable: true, defaultValue: ""),
                    Address_PostalCode = table.Column<string>(maxLength: 50, nullable: true, defaultValue: ""),
                    Address_Country = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                schema: "TicketScalper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    IsGeneralAdmission = table.Column<bool>(nullable: false, defaultValue: false),
                    VenueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Venues_VenueId",
                        column: x => x.VenueId,
                        principalSchema: "TicketScalper",
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActShows",
                schema: "TicketScalper",
                columns: table => new
                {
                    ActId = table.Column<int>(nullable: false),
                    ShowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActShows", x => new { x.ActId, x.ShowId });
                    table.ForeignKey(
                        name: "FK_ActShows_Acts_ActId",
                        column: x => x.ActId,
                        principalSchema: "TicketScalper",
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActShows_Shows_ShowId",
                        column: x => x.ShowId,
                        principalSchema: "TicketScalper",
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "TicketScalper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seat = table.Column<string>(maxLength: 20, nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ShowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Shows_ShowId",
                        column: x => x.ShowId,
                        principalSchema: "TicketScalper",
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Acts",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Flute Tour", "Jethro Tull" },
                    { 2, "The Boss Across the World", "Bruce Springsteen" },
                    { 3, "We're Still Alive Tour", "Styx" }
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Venues",
                columns: new[] { "Id", "Name", "Phone", "Address_Address1", "Address_CityTown", "Address_Country", "Address_PostalCode", "Address_StateProvince" },
                values: new object[,]
                {
                    { 1, "The Omni", "(404) 555-1212", "123 Peachtree St", "Atlanta", "USA", "30303", "GA" },
                    { 2, "Variety Playhouse", "(404) 555-1213", "123 Euclid Avenue", "Atlanta", "USA", "30307", "GA" }
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Shows",
                columns: new[] { "Id", "Length", "Name", "StartDate", "VenueId" },
                values: new object[] { 2, 1, "Bruce!", new DateTime(2020, 11, 4, 5, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Shows",
                columns: new[] { "Id", "Length", "Name", "StartDate", "VenueId" },
                values: new object[] { 3, 1, "Bruce!", new DateTime(2020, 11, 3, 5, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Shows",
                columns: new[] { "Id", "IsGeneralAdmission", "Length", "Name", "StartDate", "VenueId" },
                values: new object[] { 1, true, 1, "Jethro Tull and Styx", new DateTime(2020, 11, 1, 4, 0, 0, 0, DateTimeKind.Utc), 2 });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "ActShows",
                columns: new[] { "ActId", "ShowId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 1 },
                    { 1, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                schema: "TicketScalper",
                table: "Tickets",
                columns: new[] { "Id", "CurrentPrice", "Date", "OriginalPrice", "Seat", "ShowId" },
                values: new object[,]
                {
                    { 12, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "F14", 2 },
                    { 13, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "G01", 2 },
                    { 14, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "G02", 2 },
                    { 15, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "G03", 2 },
                    { 16, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "G04", 2 },
                    { 7, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 10, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "F12", 2 },
                    { 9, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "F11", 2 },
                    { 1, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 2, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 3, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 4, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 5, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 6, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 },
                    { 11, 299.99m, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 129m, "F13", 2 },
                    { 8, 99.99m, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.99m, "General Admission", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActShows_ShowId",
                schema: "TicketScalper",
                table: "ActShows",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_VenueId",
                schema: "TicketScalper",
                table: "Shows",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowId",
                schema: "TicketScalper",
                table: "Tickets",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActShows",
                schema: "TicketScalper");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "TicketScalper");

            migrationBuilder.DropTable(
                name: "Acts",
                schema: "TicketScalper");

            migrationBuilder.DropTable(
                name: "Shows",
                schema: "TicketScalper");

            migrationBuilder.DropTable(
                name: "Venues",
                schema: "TicketScalper");
        }
    }
}
