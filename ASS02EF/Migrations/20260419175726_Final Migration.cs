using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASS02EF.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attendees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeaddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeaddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeaddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeaddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaxAttendees = table.Column<int>(type: "int", nullable: false),
                    parenteventId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_events_parenteventId",
                        column: x => x.parenteventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orginazers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    companyname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isverfied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orginazers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "badges",
                columns: table => new
                {
                    badgenumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tier = table.Column<int>(type: "int", nullable: false),
                    attendeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_badges", x => x.badgenumber);
                    table.ForeignKey(
                        name: "FK_badges_attendees_attendeid",
                        column: x => x.attendeid,
                        principalTable: "attendees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attendee_event",
                columns: table => new
                {
                    Attendeeid = table.Column<int>(type: "int", nullable: false),
                    Eventid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendee_event", x => new { x.Eventid, x.Attendeeid });
                    table.ForeignKey(
                        name: "FK_attendee_event_attendees_Attendeeid",
                        column: x => x.Attendeeid,
                        principalTable: "attendees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attendee_event_events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biography = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orginazerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profiles_orginazers_orginazerID",
                        column: x => x.orginazerID,
                        principalTable: "orginazers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendee_event_Attendeeid",
                table: "attendee_event",
                column: "Attendeeid");

            migrationBuilder.CreateIndex(
                name: "IX_badges_attendeid",
                table: "badges",
                column: "attendeid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_events_parenteventId",
                table: "events",
                column: "parenteventId");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_orginazerID",
                table: "profiles",
                column: "orginazerID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendee_event");

            migrationBuilder.DropTable(
                name: "badges");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "attendees");

            migrationBuilder.DropTable(
                name: "orginazers");
        }
    }
}
