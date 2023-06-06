using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flight_controls",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    departure_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    departure_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    arrival_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    arrival_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    gate = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    plane_capacity = table.Column<int>(type: "integer", nullable: false),
                    plane_model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flight_controls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purchasers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaser_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookings", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookings_purchasers_purchaser_temp_id",
                        column: x => x.purchaser_id,
                        principalTable: "purchasers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    booking_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flight_control_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price_currency = table.Column<string>(type: "text", nullable: false),
                    price_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    seat_number = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    seat_occupied = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tickets", x => x.id);
                    table.ForeignKey(
                        name: "fk_tickets_bookings_booking_temp_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tickets_flight_controls_flight_control_id1",
                        column: x => x.flight_control_id,
                        principalTable: "flight_controls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bookings_purchaser_id",
                table: "bookings",
                column: "purchaser_id");

            migrationBuilder.CreateIndex(
                name: "ix_flight_controls_number",
                table: "flight_controls",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchasers_email",
                table: "purchasers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tickets_booking_id",
                table: "tickets",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "ix_tickets_flight_control_id",
                table: "tickets",
                column: "flight_control_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "flight_controls");

            migrationBuilder.DropTable(
                name: "purchasers");
        }
    }
}
