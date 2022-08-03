using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    IsValid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseReference = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HostRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataFromExport = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    HostAge = table.Column<int>(type: "INTEGER", nullable: false),
                    BuildingNameNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Town = table.Column<string>(type: "TEXT", nullable: true),
                    County = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true),
                    InitialHomeVisit = table.Column<string>(type: "TEXT", nullable: true),
                    ProformaInvoiceGivenToHost = table.Column<bool>(type: "INTEGER", nullable: false),
                    BankDetailsConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProformaSignedByCaiw = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FamilyNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfChildrenArrived = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfAdultsArrived = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfArrivalUk = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfArrivalAtAddress = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CashAllowance = table.Column<decimal>(type: "TEXT", nullable: false),
                    VodafoneSimGiven = table.Column<bool>(type: "INTEGER", nullable: false),
                    NiApplicationMade = table.Column<bool>(type: "INTEGER", nullable: false),
                    UcRegistration = table.Column<bool>(type: "INTEGER", nullable: false),
                    UcApplicationMade = table.Column<bool>(type: "INTEGER", nullable: false),
                    PensionCredit = table.Column<bool>(type: "INTEGER", nullable: false),
                    BusAppDownloadedToPhone = table.Column<bool>(type: "INTEGER", nullable: false),
                    GpApplicationSubmitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    NameOfSurgery = table.Column<string>(type: "TEXT", nullable: true),
                    EsolEnrolmentAtIwCollege = table.Column<bool>(type: "INTEGER", nullable: false),
                    BiometricResidencePermitAppliedFor = table.Column<bool>(type: "INTEGER", nullable: false),
                    BiometricResidencePermitReceived = table.Column<bool>(type: "INTEGER", nullable: false),
                    SchoolPlace = table.Column<bool>(type: "INTEGER", nullable: false),
                    NameOfSchool = table.Column<string>(type: "TEXT", nullable: true),
                    SchoolYearStartedSchool = table.Column<int>(type: "INTEGER", nullable: false),
                    HomeToSchoolTransport = table.Column<string>(type: "TEXT", nullable: true),
                    PermissionToShareDataWithOtherUkrainianArrivals = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionForCaiwToHold = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionToShareContactInformationWithFaithOrganisation = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionToShareEmailAddressWithSv = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestRecord_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeVisitRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VisitStatusId = table.Column<int>(type: "INTEGER", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HostsVisited = table.Column<string>(type: "TEXT", nullable: true),
                    GuestsVisited = table.Column<string>(type: "TEXT", nullable: true),
                    VisitorName = table.Column<string>(type: "TEXT", nullable: true),
                    IsTranslatorNeeded = table.Column<bool>(type: "INTEGER", nullable: false),
                    TranslationLanguage = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatorName = table.Column<string>(type: "TEXT", nullable: true),
                    VisitNotes = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeVisitRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeVisitRecord_VisitStatus_VisitStatusId",
                        column: x => x.VisitStatusId,
                        principalTable: "VisitStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CaseInvolvement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HostRecordId = table.Column<int>(type: "INTEGER", nullable: true),
                    GuestRecordId = table.Column<int>(type: "INTEGER", nullable: true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    FromDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CaseRecordId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseInvolvement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseInvolvement_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseInvolvement_CaseRecord_CaseRecordId",
                        column: x => x.CaseRecordId,
                        principalTable: "CaseRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseInvolvement_GuestRecord_GuestRecordId",
                        column: x => x.GuestRecordId,
                        principalTable: "GuestRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseInvolvement_HostRecord_HostRecordId",
                        column: x => x.HostRecordId,
                        principalTable: "HostRecord",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Other/not specified" });

            migrationBuilder.InsertData(
                table: "VisitStatus",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Scheduled" });

            migrationBuilder.InsertData(
                table: "VisitStatus",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "VisitStatus",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Complete" });

            migrationBuilder.CreateIndex(
                name: "IX_CaseInvolvement_AppUserId",
                table: "CaseInvolvement",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInvolvement_CaseRecordId",
                table: "CaseInvolvement",
                column: "CaseRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInvolvement_GuestRecordId",
                table: "CaseInvolvement",
                column: "GuestRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInvolvement_HostRecordId",
                table: "CaseInvolvement",
                column: "HostRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRecord_GenderId",
                table: "GuestRecord",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeVisitRecord_VisitStatusId",
                table: "HomeVisitRecord",
                column: "VisitStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseInvolvement");

            migrationBuilder.DropTable(
                name: "HomeVisitRecord");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "CaseRecord");

            migrationBuilder.DropTable(
                name: "GuestRecord");

            migrationBuilder.DropTable(
                name: "HostRecord");

            migrationBuilder.DropTable(
                name: "VisitStatus");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
