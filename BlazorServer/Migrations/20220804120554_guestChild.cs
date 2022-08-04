using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Migrations
{
    public partial class guestChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsolEnrolmentAtIwCollege",
                table: "GuestRecord");

            migrationBuilder.DropColumn(
                name: "HomeToSchoolTransport",
                table: "GuestRecord");

            migrationBuilder.DropColumn(
                name: "NameOfSchool",
                table: "GuestRecord");

            migrationBuilder.DropColumn(
                name: "SchoolPlace",
                table: "GuestRecord");

            migrationBuilder.DropColumn(
                name: "SchoolYearStartedSchool",
                table: "GuestRecord");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "CaseInvolvement");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "CaseInvolvement",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VisitStatus",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "VisitStatus",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HostRecord",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "HomeVisitRecord",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HomeVisitRecord",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "GuestRecord",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GuestRecord",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Genders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Genders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CaseRecord",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AppUser",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AppUser",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GuestChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EsolEnrolmentAtIwCollege = table.Column<bool>(type: "INTEGER", nullable: false),
                    SchoolPlace = table.Column<bool>(type: "INTEGER", nullable: false),
                    NameOfSchool = table.Column<string>(type: "TEXT", nullable: true),
                    SchoolYearStartedSchool = table.Column<int>(type: "INTEGER", nullable: true),
                    HomeToSchoolTransport = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestChild_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuestGuestChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestChildId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    GuestRecordId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestGuestChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestGuestChild_GuestChild_GuestChildId",
                        column: x => x.GuestChildId,
                        principalTable: "GuestChild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestGuestChild_GuestRecord_GuestRecordId",
                        column: x => x.GuestRecordId,
                        principalTable: "GuestRecord",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "VisitStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "VisitStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: "");

            migrationBuilder.UpdateData(
                table: "VisitStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: "");

            migrationBuilder.CreateIndex(
                name: "IX_GuestChild_GenderId",
                table: "GuestChild",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestGuestChild_GuestChildId",
                table: "GuestGuestChild",
                column: "GuestChildId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestGuestChild_GuestRecordId",
                table: "GuestGuestChild",
                column: "GuestRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestGuestChild");

            migrationBuilder.DropTable(
                name: "GuestChild");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VisitStatus");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "VisitStatus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CaseRecord");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "CaseInvolvement",
                newName: "FromDate");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HostRecord",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "HomeVisitRecord",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HomeVisitRecord",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "GuestRecord",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GuestRecord",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<bool>(
                name: "EsolEnrolmentAtIwCollege",
                table: "GuestRecord",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HomeToSchoolTransport",
                table: "GuestRecord",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfSchool",
                table: "GuestRecord",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolPlace",
                table: "GuestRecord",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SchoolYearStartedSchool",
                table: "GuestRecord",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "CaseInvolvement",
                type: "TEXT",
                nullable: true);
        }
    }
}
