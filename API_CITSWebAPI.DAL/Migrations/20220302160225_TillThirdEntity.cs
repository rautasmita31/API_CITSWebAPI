using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_CITSWebAPI.DAL.Migrations
{
    public partial class TillThirdEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    Cname = table.Column<string>(maxLength: 50, nullable: false),
                    CAddress = table.Column<string>(maxLength: 100, nullable: false),
                    ContactNumber = table.Column<double>(nullable: false),
                    CLogo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.Cname);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Management",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAddress = table.Column<string>(maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    ContactAddress = table.Column<string>(maxLength: 100, nullable: false),
                    MobileNumber = table.Column<double>(nullable: false),
                    DOJ = table.Column<DateTime>(nullable: false),
                    BasicSalary = table.Column<double>(nullable: false),
                    Profession = table.Column<string>(maxLength: 100, nullable: false),
                    Resume = table.Column<string>(maxLength: 200, nullable: false),
                    OfferLetter = table.Column<string>(maxLength: 200, nullable: false),
                    CompanyDetailsCompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Management", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Emp_Management_CompanyDetails_CompanyDetailsCompanyName",
                        column: x => x.CompanyDetailsCompanyName,
                        principalTable: "CompanyDetails",
                        principalColumn: "Cname",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance_Management",
                columns: table => new
                {
                    AttendanceManagementId = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Intime = table.Column<DateTime>(name: "In-time", nullable: false),
                    Outtime = table.Column<DateTime>(name: "Out-time", nullable: false),
                    LateHours = table.Column<int>(name: "Late-Hours", nullable: false),
                    HalfDayLeaves = table.Column<int>(name: "Half-Day-Leaves", nullable: false),
                    Notes = table.Column<string>(maxLength: 100, nullable: false),
                    EmployeeManagementEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance_Management", x => x.AttendanceManagementId);
                    table.ForeignKey(
                        name: "FK_Attendance_Management_Emp_Management_EmployeeManagementEmployeeId",
                        column: x => x.EmployeeManagementEmployeeId,
                        principalTable: "Emp_Management",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Management_EmployeeManagementEmployeeId",
                table: "Attendance_Management",
                column: "EmployeeManagementEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Management_CompanyDetailsCompanyName",
                table: "Emp_Management",
                column: "CompanyDetailsCompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance_Management");

            migrationBuilder.DropTable(
                name: "Emp_Management");

            migrationBuilder.DropTable(
                name: "CompanyDetails");
        }
    }
}
