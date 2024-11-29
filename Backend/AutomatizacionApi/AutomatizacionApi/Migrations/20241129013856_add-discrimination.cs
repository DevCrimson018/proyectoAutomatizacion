using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatizacionApi.Migrations
{
    /// <inheritdoc />
    public partial class adddiscrimination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTickets",
                schema: "Identity");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "Identity",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                schema: "Identity",
                table: "Tickets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "Identity",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Identity",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "AspNetRoles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                schema: "Identity",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "ApplicationUser",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "License",
                schema: "Identity",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                schema: "Identity",
                table: "ApplicationUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusStatuses",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectionLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ApplicationUser_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Identity",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeBus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_ApplicationUser_DriverId",
                        column: x => x.DriverId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buses_BusStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Identity",
                        principalTable: "BusStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketsCodes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsCodes_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "Identity",
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LocationId",
                schema: "Identity",
                table: "Tickets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_RoleId",
                schema: "Identity",
                table: "ApplicationUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DriverId",
                schema: "Identity",
                table: "Buses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_StatusId",
                schema: "Identity",
                table: "Buses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                schema: "Identity",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketId",
                schema: "Identity",
                table: "Reservations",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsCodes_ReservationId",
                schema: "Identity",
                table: "TicketsCodes",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetRoles_RoleId",
                schema: "Identity",
                table: "ApplicationUser",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_LocationId",
                schema: "Identity",
                table: "Tickets",
                column: "LocationId",
                principalSchema: "Identity",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetRoles_RoleId",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_LocationId",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Buses",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TicketsCodes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "BusStatuses",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_LocationId",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_RoleId",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "Identity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Cedula",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "License",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "Identity",
                table: "ApplicationUser");

            migrationBuilder.CreateTable(
                name: "UserTickets",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTickets", x => new { x.UserId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_UserTickets_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Identity",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTickets_TicketId",
                schema: "Identity",
                table: "UserTickets",
                column: "TicketId");
        }
    }
}
