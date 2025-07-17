using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceReportSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LoginPassword = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActionTakenWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTakenWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActionTakenWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionTakenWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FollowupActionWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowupActionNo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowupActionWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FollowupActionWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowupActionWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormStatusWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormStatusWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormStatusWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormStatusWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FurtherActionTakenWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurtherActionTakenWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FurtherActionTakenWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FurtherActionTakenWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueFoundWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueFoundWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IssueFoundWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueFoundWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueReportWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueReportWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IssueReportWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueReportWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocationWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNoWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNoWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectNoWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectNoWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceTypeWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTypeWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemWarehouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemWarehouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SystemWarehouses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemWarehouses_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReportForms",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectNoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowupActionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FailureDetectedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReportForms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceReportForms_FollowupActionWarehouses_FollowupActionID",
                        column: x => x.FollowupActionID,
                        principalTable: "FollowupActionWarehouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReportForms_LocationWarehouses_LocationID",
                        column: x => x.LocationID,
                        principalTable: "LocationWarehouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReportForms_ProjectNoWarehouses_ProjectNoID",
                        column: x => x.ProjectNoID,
                        principalTable: "ProjectNoWarehouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReportForms_SystemWarehouses_SystemID",
                        column: x => x.SystemID,
                        principalTable: "SystemWarehouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReportForms_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceReportForms_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionTaken",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTakenWarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceReportFormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTaken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActionTaken_ServiceReportForms_ServiceReportFormID",
                        column: x => x.ServiceReportFormID,
                        principalTable: "ServiceReportForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionTaken_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ActionTaken_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FormStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormStatusWarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceReportFormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormStatus_ServiceReportForms_ServiceReportFormID",
                        column: x => x.ServiceReportFormID,
                        principalTable: "ServiceReportForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormStatus_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FormStatus_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FurtherActionTaken",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FurtherActionTakenWarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceReportFormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurtherActionTaken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FurtherActionTaken_ServiceReportForms_ServiceReportFormID",
                        column: x => x.ServiceReportFormID,
                        principalTable: "ServiceReportForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurtherActionTaken_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FurtherActionTaken_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "IssueFound",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueFoundWarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceReportFormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueFound", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IssueFound_ServiceReportForms_ServiceReportFormID",
                        column: x => x.ServiceReportFormID,
                        principalTable: "ServiceReportForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueFound_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "IssueReported",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueReportWarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceReportFormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueReported", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IssueReported_ServiceReportForms_ServiceReportFormID",
                        column: x => x.ServiceReportFormID,
                        principalTable: "ServiceReportForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueReported_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeWarehouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceReportFormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceType_ServiceReportForms_ServiceReportFormID",
                        column: x => x.ServiceReportFormID,
                        principalTable: "ServiceReportForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceType_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaken_CreatedBy",
                table: "ActionTaken",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaken_ServiceReportFormID",
                table: "ActionTaken",
                column: "ServiceReportFormID");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaken_UpdatedBy",
                table: "ActionTaken",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTakenWarehouses_CreatedBy",
                table: "ActionTakenWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTakenWarehouses_UpdatedBy",
                table: "ActionTakenWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWarehouses_CreatedBy",
                table: "CustomerWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWarehouses_UpdatedBy",
                table: "CustomerWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FollowupActionWarehouses_CreatedBy",
                table: "FollowupActionWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FollowupActionWarehouses_UpdatedBy",
                table: "FollowupActionWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FormStatus_CreatedBy",
                table: "FormStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FormStatus_ServiceReportFormID",
                table: "FormStatus",
                column: "ServiceReportFormID");

            migrationBuilder.CreateIndex(
                name: "IX_FormStatus_UpdatedBy",
                table: "FormStatus",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FormStatusWarehouses_CreatedBy",
                table: "FormStatusWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FormStatusWarehouses_UpdatedBy",
                table: "FormStatusWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTaken_CreatedBy",
                table: "FurtherActionTaken",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTaken_ServiceReportFormID",
                table: "FurtherActionTaken",
                column: "ServiceReportFormID");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTaken_UpdatedBy",
                table: "FurtherActionTaken",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTakenWarehouses_CreatedBy",
                table: "FurtherActionTakenWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FurtherActionTakenWarehouses_UpdatedBy",
                table: "FurtherActionTakenWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFound_ServiceReportFormID",
                table: "IssueFound",
                column: "ServiceReportFormID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFound_UpdatedBy",
                table: "IssueFound",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFoundWarehouses_CreatedBy",
                table: "IssueFoundWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueFoundWarehouses_UpdatedBy",
                table: "IssueFoundWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueReported_ServiceReportFormID",
                table: "IssueReported",
                column: "ServiceReportFormID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueReported_UpdatedBy",
                table: "IssueReported",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueReportWarehouses_CreatedBy",
                table: "IssueReportWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_IssueReportWarehouses_UpdatedBy",
                table: "IssueReportWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LocationWarehouses_CreatedBy",
                table: "LocationWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LocationWarehouses_UpdatedBy",
                table: "LocationWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNoWarehouses_CreatedBy",
                table: "ProjectNoWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNoWarehouses_UpdatedBy",
                table: "ProjectNoWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_CreatedBy",
                table: "ServiceReportForms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_FollowupActionID",
                table: "ServiceReportForms",
                column: "FollowupActionID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_LocationID",
                table: "ServiceReportForms",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_ProjectNoID",
                table: "ServiceReportForms",
                column: "ProjectNoID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_SystemID",
                table: "ServiceReportForms",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReportForms_UpdatedBy",
                table: "ServiceReportForms",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_ServiceReportFormID",
                table: "ServiceType",
                column: "ServiceReportFormID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_UpdatedBy",
                table: "ServiceType",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeWarehouses_CreatedBy",
                table: "ServiceTypeWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeWarehouses_UpdatedBy",
                table: "ServiceTypeWarehouses",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SystemWarehouses_CreatedBy",
                table: "SystemWarehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SystemWarehouses_UpdatedBy",
                table: "SystemWarehouses",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionTaken");

            migrationBuilder.DropTable(
                name: "ActionTakenWarehouses");

            migrationBuilder.DropTable(
                name: "CustomerWarehouses");

            migrationBuilder.DropTable(
                name: "FormStatus");

            migrationBuilder.DropTable(
                name: "FormStatusWarehouses");

            migrationBuilder.DropTable(
                name: "FurtherActionTaken");

            migrationBuilder.DropTable(
                name: "FurtherActionTakenWarehouses");

            migrationBuilder.DropTable(
                name: "IssueFound");

            migrationBuilder.DropTable(
                name: "IssueFoundWarehouses");

            migrationBuilder.DropTable(
                name: "IssueReported");

            migrationBuilder.DropTable(
                name: "IssueReportWarehouses");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "ServiceTypeWarehouses");

            migrationBuilder.DropTable(
                name: "ServiceReportForms");

            migrationBuilder.DropTable(
                name: "FollowupActionWarehouses");

            migrationBuilder.DropTable(
                name: "LocationWarehouses");

            migrationBuilder.DropTable(
                name: "ProjectNoWarehouses");

            migrationBuilder.DropTable(
                name: "SystemWarehouses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
