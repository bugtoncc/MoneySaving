using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class AddedSalary2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSalaryType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSalaryType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MSalary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    MSalaryTypeId = table.Column<int>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Overtime = table.Column<double>(nullable: false),
                    Incentive = table.Column<double>(nullable: false),
                    Bonus = table.Column<double>(nullable: false),
                    Position = table.Column<double>(nullable: false),
                    Diligence = table.Column<double>(nullable: false),
                    Food = table.Column<double>(nullable: false),
                    Vehicle = table.Column<double>(nullable: false),
                    Leave = table.Column<double>(nullable: false),
                    Award = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    SS = table.Column<double>(nullable: false),
                    PVD = table.Column<double>(nullable: false),
                    Loan = table.Column<double>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSalary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MSalary_MSalaryType_MSalaryTypeId",
                        column: x => x.MSalaryTypeId,
                        principalTable: "MSalaryType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MSalary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MSalary_MSalaryTypeId",
                table: "MSalary",
                column: "MSalaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MSalary_UserId",
                table: "MSalary",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSalary");

            migrationBuilder.DropTable(
                name: "MSalaryType");
        }
    }
}
