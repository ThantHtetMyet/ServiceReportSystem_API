using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceReportSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddFurtherActionTakenWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FurtherActionTakenID",
                table: "ServiceReportForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FurtherActionTakenWarehouse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurtherActionTakenWarehouse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FurtherActionTakenWarehouse_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FurtherActionTakenWarehouse_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_FurtherActionTakenID",
                table: "ServiceReportForms",
                column: "FurtherActionTakenID");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTakenWarehouse_CreatedBy",
                table: "FurtherActionTakenWarehouse",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTakenWarehouse_UpdatedBy",
                table: "FurtherActionTakenWarehouse",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReportForms_FurtherActionTakenWarehouse_FurtherActionTakenID",
                table: "ServiceReportForms",
                column: "FurtherActionTakenID",
                principalTable: "FurtherActionTakenWarehouse",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReportForms_FurtherActionTakenWarehouse_FurtherActionTakenID",
                table: "ServiceReportForms");

            migrationBuilder.DropTable(
                name: "FurtherActionTakenWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReportForms_FurtherActionTakenID",
                table: "ServiceReportForms");

            migrationBuilder.DropColumn(
                name: "FurtherActionTakenID",
                table: "ServiceReportForms");
        }
    }
}
