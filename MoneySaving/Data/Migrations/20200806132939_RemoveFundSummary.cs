using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class RemoveFundSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundTransaction_FundSummary_FundSummaryId",
                table: "FundTransaction");

            migrationBuilder.DropTable(
                name: "FundSummary");

            migrationBuilder.DropIndex(
                name: "IX_FundTransaction_FundSummaryId",
                table: "FundTransaction");

            migrationBuilder.DropColumn(
                name: "FundSummaryId",
                table: "FundTransaction");

            migrationBuilder.AddColumn<int>(
                name: "FundPortId",
                table: "FundTransaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FundTransaction_FundPortId",
                table: "FundTransaction",
                column: "FundPortId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundTransaction_FundPort_FundPortId",
                table: "FundTransaction",
                column: "FundPortId",
                principalTable: "FundPort",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundTransaction_FundPort_FundPortId",
                table: "FundTransaction");

            migrationBuilder.DropIndex(
                name: "IX_FundTransaction_FundPortId",
                table: "FundTransaction");

            migrationBuilder.DropColumn(
                name: "FundPortId",
                table: "FundTransaction");

            migrationBuilder.AddColumn<int>(
                name: "FundSummaryId",
                table: "FundTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FundSummary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    FundPortId = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MFundId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundSummary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FundSummary_FundPort_FundPortId",
                        column: x => x.FundPortId,
                        principalTable: "FundPort",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundSummary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundTransaction_FundSummaryId",
                table: "FundTransaction",
                column: "FundSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSummary_FundPortId",
                table: "FundSummary",
                column: "FundPortId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSummary_UserId",
                table: "FundSummary",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundTransaction_FundSummary_FundSummaryId",
                table: "FundTransaction",
                column: "FundSummaryId",
                principalTable: "FundSummary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
