using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Migrations
{
    public partial class addressRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostAge",
                table: "HostRecord");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "HostRecord",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HostRecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCurrentAddress = table.Column<bool>(type: "INTEGER", nullable: false),
                    MoveInDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MoveOutDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BuildingNameNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Town = table.Column<string>(type: "TEXT", nullable: true),
                    County = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressRecord_HostRecord_HostRecordId",
                        column: x => x.HostRecordId,
                        principalTable: "HostRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressRecord_HostRecordId",
                table: "AddressRecord",
                column: "HostRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressRecord");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "HostRecord");

            migrationBuilder.AddColumn<int>(
                name: "HostAge",
                table: "HostRecord",
                type: "INTEGER",
                nullable: true);
        }
    }
}
