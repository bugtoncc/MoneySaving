using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashflowType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashflowType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MPocket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPocket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    CashflowTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MCategory_CashflowType_CashflowTypeId",
                        column: x => x.CashflowTypeId,
                        principalTable: "CashflowType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainTransaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    MpocketId = table.Column<int>(nullable: false),
                    MCategoryId = table.Column<int>(nullable: false),
                    Detail = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MainTransaction_MCategory_MCategoryId",
                        column: x => x.MCategoryId,
                        principalTable: "MCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainTransaction_MPocket_MpocketId",
                        column: x => x.MpocketId,
                        principalTable: "MPocket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_MCategoryId",
                table: "MainTransaction",
                column: "MCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_MpocketId",
                table: "MainTransaction",
                column: "MpocketId");

            migrationBuilder.CreateIndex(
                name: "IX_MCategory_CashflowTypeId",
                table: "MCategory",
                column: "CashflowTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainTransaction");

            migrationBuilder.DropTable(
                name: "MCategory");

            migrationBuilder.DropTable(
                name: "MPocket");

            migrationBuilder.DropTable(
                name: "CashflowType");
        }
    }
}
