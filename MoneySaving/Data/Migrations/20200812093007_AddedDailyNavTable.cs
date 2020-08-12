using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class AddedDailyNavTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyNav",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundPortId = table.Column<string>(nullable: true),
                    nav_date = table.Column<DateTime>(nullable: false),
                    net_asset = table.Column<double>(nullable: false),
                    last_val = table.Column<double>(nullable: false),
                    previous_val = table.Column<double>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    MFundID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNav", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DailyNav_MFund_MFundID",
                        column: x => x.MFundID,
                        principalTable: "MFund",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyNav_MFundID",
                table: "DailyNav",
                column: "MFundID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyNav");
        }
    }
}
