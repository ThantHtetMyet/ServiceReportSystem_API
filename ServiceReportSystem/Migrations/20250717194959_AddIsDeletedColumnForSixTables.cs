using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceReportSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedColumnForSixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServiceType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IssueReported",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IssueFound",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FurtherActionTaken",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FormStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActionTaken",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServiceType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IssueReported");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IssueFound");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FurtherActionTaken");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FormStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActionTaken");
        }
    }
}
