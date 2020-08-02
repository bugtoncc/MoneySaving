using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class AddTableForFundWithDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundPort",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundPort", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FundPort_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAmc",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTh = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAmc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MFundFlowType",
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
                    table.PrimaryKey("PK_MFundFlowType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MFund",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTh = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    Abbr = table.Column<string>(nullable: false),
                    RegisId = table.Column<string>(nullable: false),
                    RegisDate = table.Column<DateTime>(nullable: false),
                    CancelDate = table.Column<DateTime>(nullable: false),
                    FundStatus = table.Column<string>(nullable: false),
                    MAmcId = table.Column<int>(nullable: false),
                    PermitUs = table.Column<string>(nullable: true),
                    CountryFlag = table.Column<int>(nullable: false),
                    StatusFlag = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFund", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MFund_MAmc_MAmcId",
                        column: x => x.MAmcId,
                        principalTable: "MAmc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundSummary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundPortId = table.Column<int>(nullable: false),
                    MFundId = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Unit = table.Column<double>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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
                        name: "FK_FundSummary_MFund_MFundId",
                        column: x => x.MFundId,
                        principalTable: "MFund",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundSummary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundTransaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    FundSummaryId = table.Column<int>(nullable: false),
                    FundFlowTypeId = table.Column<int>(nullable: false),
                    MFundId = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Nav = table.Column<double>(nullable: false),
                    Units = table.Column<double>(nullable: false),
                    NavConfirmed = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MFundFlowTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FundTransaction_FundSummary_FundSummaryId",
                        column: x => x.FundSummaryId,
                        principalTable: "FundSummary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundTransaction_MFundFlowType_MFundFlowTypeID",
                        column: x => x.MFundFlowTypeID,
                        principalTable: "MFundFlowType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundTransaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundPort_UserId",
                table: "FundPort",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSummary_FundPortId",
                table: "FundSummary",
                column: "FundPortId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSummary_MFundId",
                table: "FundSummary",
                column: "MFundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSummary_UserId",
                table: "FundSummary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundTransaction_FundSummaryId",
                table: "FundTransaction",
                column: "FundSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundTransaction_MFundFlowTypeID",
                table: "FundTransaction",
                column: "MFundFlowTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FundTransaction_UserId",
                table: "FundTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MFund_MAmcId",
                table: "MFund",
                column: "MAmcId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundTransaction");

            migrationBuilder.DropTable(
                name: "FundSummary");

            migrationBuilder.DropTable(
                name: "MFundFlowType");

            migrationBuilder.DropTable(
                name: "FundPort");

            migrationBuilder.DropTable(
                name: "MFund");

            migrationBuilder.DropTable(
                name: "MAmc");
        }
    }
}
