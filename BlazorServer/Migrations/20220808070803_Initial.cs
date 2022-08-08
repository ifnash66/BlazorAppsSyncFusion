using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseInvolvement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseRecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    HostRecordId = table.Column<int>(type: "INTEGER", nullable: true),
                    GuestRecordId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseInvolvement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseNoteCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseNoteCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseReference = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
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
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseRecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaseNoteCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    NoteText = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseNote_CaseNoteCategory_CaseNoteCategoryId",
                        column: x => x.CaseNoteCategoryId,
                        principalTable: "CaseNoteCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseNote_CaseRecord_CaseRecordId",
                        column: x => x.CaseRecordId,
                        principalTable: "CaseRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfChildrenArrived = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfAdultsArrived = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfArrivalUk = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfArrivalAtAddress = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CashAllowance = table.Column<decimal>(type: "TEXT", nullable: true),
                    VodafoneSimGiven = table.Column<bool>(type: "INTEGER", nullable: false),
                    NiApplicationMade = table.Column<bool>(type: "INTEGER", nullable: false),
                    UcRegistration = table.Column<bool>(type: "INTEGER", nullable: false),
                    UcApplicationMade = table.Column<bool>(type: "INTEGER", nullable: false),
                    PensionCredit = table.Column<bool>(type: "INTEGER", nullable: false),
                    BusAppDownloadedToPhone = table.Column<bool>(type: "INTEGER", nullable: false),
                    GpApplicationSubmitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    NameOfSurgery = table.Column<string>(type: "TEXT", nullable: true),
                    BiometricResidencePermitAppliedFor = table.Column<bool>(type: "INTEGER", nullable: false),
                    BiometricResidencePermitReceived = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionToShareDataWithOtherUkrainianArrivals = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionForCaiwToHold = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionToShareContactInformationWithFaithOrganisation = table.Column<bool>(type: "INTEGER", nullable: false),
                    PermissionToShareEmailAddressWithSv = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestRecord_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "HomeVisitRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseRecordId = table.Column<int>(type: "INTEGER", nullable: true),
                    VisitStatusId = table.Column<int>(type: "INTEGER", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HostsVisited = table.Column<string>(type: "TEXT", nullable: true),
                    GuestsVisited = table.Column<string>(type: "TEXT", nullable: true),
                    VisitorName = table.Column<string>(type: "TEXT", nullable: true),
                    IsTranslatorNeeded = table.Column<bool>(type: "INTEGER", nullable: false),
                    TranslationLanguage = table.Column<string>(type: "TEXT", nullable: true),
                    TranslatorName = table.Column<string>(type: "TEXT", nullable: true),
                    VisitNotes = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeVisitRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeVisitRecord_CaseRecord_CaseRecordId",
                        column: x => x.CaseRecordId,
                        principalTable: "CaseRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeVisitRecord_VisitStatus_VisitStatusId",
                        column: x => x.VisitStatusId,
                        principalTable: "VisitStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuestRecordGuestChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestChildId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    GuestRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRecordGuestChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestRecordGuestChild_GuestChild_GuestChildId",
                        column: x => x.GuestChildId,
                        principalTable: "GuestChild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestRecordGuestChild_GuestRecord_GuestRecordId",
                        column: x => x.GuestRecordId,
                        principalTable: "GuestRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressRecord_HostRecordId",
                table: "AddressRecord",
                column: "HostRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseNote_CaseNoteCategoryId",
                table: "CaseNote",
                column: "CaseNoteCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseNote_CaseRecordId",
                table: "CaseNote",
                column: "CaseRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestChild_GenderId",
                table: "GuestChild",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRecord_GenderId",
                table: "GuestRecord",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRecordGuestChild_GuestChildId",
                table: "GuestRecordGuestChild",
                column: "GuestChildId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRecordGuestChild_GuestRecordId",
                table: "GuestRecordGuestChild",
                column: "GuestRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeVisitRecord_CaseRecordId",
                table: "HomeVisitRecord",
                column: "CaseRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeVisitRecord_VisitStatusId",
                table: "HomeVisitRecord",
                column: "VisitStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressRecord");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaseInvolvement");

            migrationBuilder.DropTable(
                name: "CaseNote");

            migrationBuilder.DropTable(
                name: "GuestRecordGuestChild");

            migrationBuilder.DropTable(
                name: "HomeVisitRecord");

            migrationBuilder.DropTable(
                name: "HostRecord");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CaseNoteCategory");

            migrationBuilder.DropTable(
                name: "GuestChild");

            migrationBuilder.DropTable(
                name: "GuestRecord");

            migrationBuilder.DropTable(
                name: "CaseRecord");

            migrationBuilder.DropTable(
                name: "VisitStatus");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
