using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericCalendar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSubtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RequiresTraining = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FlightNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    SeatClass = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Row = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSeats_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Interviewer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CandidateEmail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewSlots_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpotNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsCovered = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportsFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FieldType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HasLighting = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportsFields_BookableItems_Id",
                        column: x => x.Id,
                        principalTable: "BookableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_SerialNumber",
                table: "Equipment",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_FlightNumber_Row_Number",
                table: "FlightSeats",
                columns: new[] { "FlightNumber", "Row", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSlots_CandidateEmail",
                table: "InterviewSlots",
                column: "CandidateEmail");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSlots_Interviewer",
                table: "InterviewSlots",
                column: "Interviewer");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_Level_SpotNumber",
                table: "ParkingSpots",
                columns: new[] { "Level", "SpotNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportsFields_FieldType",
                table: "SportsFields",
                column: "FieldType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "FlightSeats");

            migrationBuilder.DropTable(
                name: "InterviewSlots");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "SportsFields");
        }
    }
}
