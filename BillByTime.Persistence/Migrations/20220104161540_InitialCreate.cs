using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillByTime.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "TenantManager",
                columns: table => new
                {
                    TenantManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SmsNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantManager", x => x.TenantManagerId);
                    table.ForeignKey(
                        name: "FK_TenantManager_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SmsNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Worker_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantManager2ClientOrg",
                columns: table => new
                {
                    TenantManager2ClientOrgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantManager2ClientOrg", x => x.TenantManager2ClientOrgId);
                    table.ForeignKey(
                        name: "FK_TenantManager2ClientOrg_TenantManager_TenantManagerId",
                        column: x => x.TenantManagerId,
                        principalTable: "TenantManager",
                        principalColumn: "TenantManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrg",
                columns: table => new
                {
                    ClientOrgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenantManager2ClientOrgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrg", x => x.ClientOrgId);
                    table.ForeignKey(
                        name: "FK_ClientOrg_TenantManager2ClientOrg_TenantManager2ClientOrgId",
                        column: x => x.TenantManager2ClientOrgId,
                        principalTable: "TenantManager2ClientOrg",
                        principalColumn: "TenantManager2ClientOrgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientManager",
                columns: table => new
                {
                    ClientManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SmsNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientOrgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientManager", x => x.ClientManagerId);
                    table.ForeignKey(
                        name: "FK_ClientManager_ClientOrg_ClientOrgId",
                        column: x => x.ClientOrgId,
                        principalTable: "ClientOrg",
                        principalColumn: "ClientOrgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitCharge = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    ClientOrgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_ClientOrg_ClientOrgId",
                        column: x => x.ClientOrgId,
                        principalTable: "ClientOrg",
                        principalColumn: "ClientOrgId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ClientOrgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_ClientOrg_ClientOrgId",
                        column: x => x.ClientOrgId,
                        principalTable: "ClientOrg",
                        principalColumn: "ClientOrgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Tuesday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Wednesday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Thursday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Friday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Saturday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Sunday = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.TimesheetId);
                    table.ForeignKey(
                        name: "FK_Timesheet_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timesheet_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId");
                });

            migrationBuilder.CreateTable(
                name: "TimesheetHistory",
                columns: table => new
                {
                    TimesheetHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TimesheetId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ClientManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetHistory", x => x.TimesheetHistoryId);
                    table.ForeignKey(
                        name: "FK_TimesheetHistory_ClientManager_ClientManagerId",
                        column: x => x.ClientManagerId,
                        principalTable: "ClientManager",
                        principalColumn: "ClientManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetHistory_Timesheet_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "TimesheetId");
                    table.ForeignKey(
                        name: "FK_TimesheetHistory_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "WorkerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientManager_ClientOrgId",
                table: "ClientManager",
                column: "ClientOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrg_TenantManager2ClientOrgId",
                table: "ClientOrg",
                column: "TenantManager2ClientOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientOrgId",
                table: "Contract",
                column: "ClientOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_WorkerId",
                table: "Contract",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_ClientOrgId",
                table: "PurchaseOrder",
                column: "ClientOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_Name",
                table: "Tenant",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantManager_Email",
                table: "TenantManager",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantManager_TenantId",
                table: "TenantManager",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantManager2ClientOrg_TenantManagerId",
                table: "TenantManager2ClientOrg",
                column: "TenantManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_ContractId",
                table: "Timesheet",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_PurchaseOrderId",
                table: "Timesheet",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetHistory_ClientManagerId",
                table: "TimesheetHistory",
                column: "ClientManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetHistory_TimesheetId",
                table: "TimesheetHistory",
                column: "TimesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetHistory_WorkerId",
                table: "TimesheetHistory",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_TenantId",
                table: "Worker",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimesheetHistory");

            migrationBuilder.DropTable(
                name: "ClientManager");

            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "ClientOrg");

            migrationBuilder.DropTable(
                name: "TenantManager2ClientOrg");

            migrationBuilder.DropTable(
                name: "TenantManager");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
