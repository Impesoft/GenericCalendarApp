using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GenericCalendar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookableItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BookedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookableItems_BookableItemId",
                        column: x => x.BookableItemId,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Row = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMeetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Participants = table.Column<string>(type: "TEXT", nullable: false),
                    Organizer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMeetings_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookableItems",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3a91263e-61a2-4b78-927f-01a8f331ec11"), "Front row left", "Seat A1" },
                    { new Guid("6e282e43-8825-42e6-a3a1-1f1eb9f7a0c3"), "Weekly check-in", "Weekly Sync" },
                    { new Guid("c4f7a089-5bc6-43d0-b95d-739c2489ac4d"), "Medium room", "Meeting Room A" },
                    { new Guid("ed52fdcf-87fa-4f6d-ae09-b15419fecd72"), "Large presentation room", "Main Hall" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookableItemId", "BookedBy", "End", "Start", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), new Guid("ed52fdcf-87fa-4f6d-ae09-b15419fecd72"), "alice@example.com", new DateTime(2025, 4, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Project Kickoff", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000102"), new Guid("3a91263e-61a2-4b78-927f-01a8f331ec11"), "carol@example.com", new DateTime(2025, 4, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), "Seat A1 Reserved", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Floor" },
                values: new object[,]
                {
                    { new Guid("c4f7a089-5bc6-43d0-b95d-739c2489ac4d"), 12, 2 },
                    { new Guid("ed52fdcf-87fa-4f6d-ae09-b15419fecd72"), 100, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "Row" },
                values: new object[] { new Guid("3a91263e-61a2-4b78-927f-01a8f331ec11"), 1, "A" });

            migrationBuilder.InsertData(
                table: "TeamMeetings",
                columns: new[] { "Id", "Organizer", "Participants" },
                values: new object[] { new Guid("6e282e43-8825-42e6-a3a1-1f1eb9f7a0c3"), "lead@example.com", "alice@example.com;bob@example.com" });

            migrationBuilder.CreateIndex(
                name: "IX_BookableItems_Name",
                table: "BookableItems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookableItemId_Start_End",
                table: "Bookings",
                columns: new[] { "BookableItemId", "Start", "End" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Floor",
                table: "Rooms",
                column: "Floor");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_Row_Number",
                table: "Seats",
                columns: new[] { "Row", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMeetings_Organizer",
                table: "TeamMeetings",
                column: "Organizer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "TeamMeetings");

            migrationBuilder.DropTable(
                name: "BookableItems");
        }
    }
}
