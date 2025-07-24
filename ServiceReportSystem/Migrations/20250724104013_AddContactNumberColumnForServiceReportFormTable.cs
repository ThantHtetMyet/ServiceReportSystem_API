using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceReportSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddContactNumberColumnForServiceReportFormTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "ServiceReportForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_ServiceTypeWarehouseID",
                table: "ServiceType",
                column: "ServiceTypeWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueReported_CreatedBy",
                table: "IssueReported",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueReported_IssueReportWarehouseID",
                table: "IssueReported",
                column: "IssueReportWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFound_CreatedBy",
                table: "IssueFound",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFound_IssueFoundWarehouseID",
                table: "IssueFound",
                column: "IssueFoundWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTaken_FurtherActionTakenWarehouseID",
                table: "FurtherActionTaken",
                column: "FurtherActionTakenWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_FormStatus_FormStatusWarehouseID",
                table: "FormStatus",
                column: "FormStatusWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaken_ActionTakenWarehouseID",
                table: "ActionTaken",
                column: "ActionTakenWarehouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionTaken_ActionTakenWarehouses_ActionTakenWarehouseID",
                table: "ActionTaken",
                column: "ActionTakenWarehouseID",
                principalTable: "ActionTakenWarehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormStatus_FormStatusWarehouses_FormStatusWarehouseID",
                table: "FormStatus",
                column: "FormStatusWarehouseID",
                principalTable: "FormStatusWarehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FurtherActionTaken_FurtherActionTakenWarehouses_FurtherActionTakenWarehouseID",
                table: "FurtherActionTaken",
                column: "FurtherActionTakenWarehouseID",
                principalTable: "FurtherActionTakenWarehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueFound_IssueFoundWarehouses_IssueFoundWarehouseID",
                table: "IssueFound",
                column: "IssueFoundWarehouseID",
                principalTable: "IssueFoundWarehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueFound_Users_CreatedBy",
                table: "IssueFound",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueReported_IssueReportWarehouses_IssueReportWarehouseID",
                table: "IssueReported",
                column: "IssueReportWarehouseID",
                principalTable: "IssueReportWarehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueReported_Users_CreatedBy",
                table: "IssueReported",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceType_ServiceTypeWarehouses_ServiceTypeWarehouseID",
                table: "ServiceType",
                column: "ServiceTypeWarehouseID",
                principalTable: "ServiceTypeWarehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionTaken_ActionTakenWarehouses_ActionTakenWarehouseID",
                table: "ActionTaken");

            migrationBuilder.DropForeignKey(
                name: "FK_FormStatus_FormStatusWarehouses_FormStatusWarehouseID",
                table: "FormStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_FurtherActionTaken_FurtherActionTakenWarehouses_FurtherActionTakenWarehouseID",
                table: "FurtherActionTaken");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueFound_IssueFoundWarehouses_IssueFoundWarehouseID",
                table: "IssueFound");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueFound_Users_CreatedBy",
                table: "IssueFound");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueReported_IssueReportWarehouses_IssueReportWarehouseID",
                table: "IssueReported");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueReported_Users_CreatedBy",
                table: "IssueReported");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceType_ServiceTypeWarehouses_ServiceTypeWarehouseID",
                table: "ServiceType");

            migrationBuilder.DropIndex(
                name: "IX_ServiceType_ServiceTypeWarehouseID",
                table: "ServiceType");

            migrationBuilder.DropIndex(
                name: "IX_IssueReported_CreatedBy",
                table: "IssueReported");

            migrationBuilder.DropIndex(
                name: "IX_IssueReported_IssueReportWarehouseID",
                table: "IssueReported");

            migrationBuilder.DropIndex(
                name: "IX_IssueFound_CreatedBy",
                table: "IssueFound");

            migrationBuilder.DropIndex(
                name: "IX_IssueFound_IssueFoundWarehouseID",
                table: "IssueFound");

            migrationBuilder.DropIndex(
                name: "IX_FurtherActionTaken_FurtherActionTakenWarehouseID",
                table: "FurtherActionTaken");

            migrationBuilder.DropIndex(
                name: "IX_FormStatus_FormStatusWarehouseID",
                table: "FormStatus");

            migrationBuilder.DropIndex(
                name: "IX_ActionTaken_ActionTakenWarehouseID",
                table: "ActionTaken");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "ServiceReportForms");
        }
    }
}
