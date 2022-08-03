using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Migrations
{
    public partial class CaseNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseInvolvement_CaseRecord_CaseRecordId",
                table: "CaseInvolvement");

            migrationBuilder.AlterColumn<int>(
                name: "CaseRecordId",
                table: "CaseInvolvement",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseInvolvement_CaseRecord_CaseRecordId",
                table: "CaseInvolvement",
                column: "CaseRecordId",
                principalTable: "CaseRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseInvolvement_CaseRecord_CaseRecordId",
                table: "CaseInvolvement");

            migrationBuilder.AlterColumn<int>(
                name: "CaseRecordId",
                table: "CaseInvolvement",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseInvolvement_CaseRecord_CaseRecordId",
                table: "CaseInvolvement",
                column: "CaseRecordId",
                principalTable: "CaseRecord",
                principalColumn: "Id");
        }
    }
}
