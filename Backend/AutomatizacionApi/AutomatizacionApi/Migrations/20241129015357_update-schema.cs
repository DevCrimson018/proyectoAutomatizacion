using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatizacionApi.Migrations
{
    /// <inheritdoc />
    public partial class updateschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsCodes_Reservations_ReservationId",
                schema: "Identity",
                table: "TicketsCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsCodes",
                schema: "Identity",
                table: "TicketsCodes");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Tickets",
                schema: "Identity",
                newName: "Tickets",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Reservations",
                schema: "Identity",
                newName: "Reservations",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "Identity",
                newName: "Locations",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BusStatuses",
                schema: "Identity",
                newName: "BusStatuses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Buses",
                schema: "Identity",
                newName: "Buses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "TicketsCodes",
                schema: "Identity",
                newName: "TicketCodes",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TicketsCodes_ReservationId",
                schema: "dbo",
                table: "TicketCodes",
                newName: "IX_TicketCodes_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCodes",
                schema: "dbo",
                table: "TicketCodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCodes_Reservations_ReservationId",
                schema: "dbo",
                table: "TicketCodes",
                column: "ReservationId",
                principalSchema: "dbo",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCodes_Reservations_ReservationId",
                schema: "dbo",
                table: "TicketCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCodes",
                schema: "dbo",
                table: "TicketCodes");

            migrationBuilder.RenameTable(
                name: "Tickets",
                schema: "dbo",
                newName: "Tickets",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Reservations",
                schema: "dbo",
                newName: "Reservations",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "dbo",
                newName: "Locations",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "BusStatuses",
                schema: "dbo",
                newName: "BusStatuses",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Buses",
                schema: "dbo",
                newName: "Buses",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "TicketCodes",
                schema: "dbo",
                newName: "TicketsCodes",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCodes_ReservationId",
                schema: "Identity",
                table: "TicketsCodes",
                newName: "IX_TicketsCodes_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsCodes",
                schema: "Identity",
                table: "TicketsCodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsCodes_Reservations_ReservationId",
                schema: "Identity",
                table: "TicketsCodes",
                column: "ReservationId",
                principalSchema: "Identity",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
