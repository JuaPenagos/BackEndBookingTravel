using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndBookingTravel.Infrastructure.SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdGender = table.Column<int>(type: "int", nullable: false),
                    IdDocumentType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_DocumentTypes_IdDocumentType",
                        column: x => x.IdDocumentType,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Genders_IdGender",
                        column: x => x.IdGender,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdRoomType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_IdRoomType",
                        column: x => x.IdRoomType,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmergencyPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    IdRoom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => new { x.IdHotel, x.IdRoom });
                    table.ForeignKey(
                        name: "FK_HotelRoom_Hotels_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoom_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBooking = table.Column<int>(type: "int", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingCustomer_Bookings_IdBooking",
                        column: x => x.IdBooking,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingCustomer_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Code", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "CC", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4085), "Cedula de Ciudadania", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4088) },
                    { 2, "TP", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4090), "Pasaporte", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4091) },
                    { 3, "PA", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4092), "Tarjeta de Identidad", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4093) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "F", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4488), "Femenino", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4489) },
                    { 2, "M", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4494), "Masculino", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4494) },
                    { 3, "O", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4496), "Otro", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4496) }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Code", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "Parejas", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4551), "Habitacion doble", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4552) },
                    { 2, "Individual", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4554), "Habitacion Sencilla", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4555) },
                    { 3, "Matrimonial", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4556), "Suite", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4557) },
                    { 4, "Familiar", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4558), "Habitacion multiple", new DateTime(2024, 8, 1, 15, 47, 7, 732, DateTimeKind.Utc).AddTicks(4559) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCustomer_IdBooking",
                table: "BookingCustomer",
                column: "IdBooking");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCustomer_IdCustomer",
                table: "BookingCustomer",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_IdRoom",
                table: "Bookings",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdDocumentType",
                table: "Customers",
                column: "IdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdGender",
                table: "Customers",
                column: "IdGender");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_IdRoom",
                table: "HotelRoom",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IdRoomType",
                table: "Rooms",
                column: "IdRoomType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCustomer");

            migrationBuilder.DropTable(
                name: "HotelRoom");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
