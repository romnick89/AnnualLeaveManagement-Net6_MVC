using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnualLeaveManagement.Web.Data.Migrations
{
    public partial class AddedAnnualLeaveTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnualLeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualLeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnualLeaveAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    AnnualLeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualLeaveAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualLeaveAllocations_AnnualLeaveTypes_AnnualLeaveTypeId",
                        column: x => x.AnnualLeaveTypeId,
                        principalTable: "AnnualLeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveAllocations_AnnualLeaveTypeId",
                table: "AnnualLeaveAllocations",
                column: "AnnualLeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualLeaveAllocations");

            migrationBuilder.DropTable(
                name: "AnnualLeaveTypes");
        }
    }
}
