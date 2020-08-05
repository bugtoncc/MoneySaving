using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class EditMFundFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundSummary_MFund_MFundId",
                table: "FundSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_FundTransaction_MFundFlowType_MFundFlowTypeID",
                table: "FundTransaction");

            migrationBuilder.DropIndex(
                name: "IX_FundSummary_MFundId",
                table: "FundSummary");

            migrationBuilder.DropColumn(
                name: "FundFlowTypeId",
                table: "FundTransaction");

            migrationBuilder.RenameColumn(
                name: "MFundFlowTypeID",
                table: "FundTransaction",
                newName: "MFundFlowTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FundTransaction_MFundFlowTypeID",
                table: "FundTransaction",
                newName: "IX_FundTransaction_MFundFlowTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "MFundFlowTypeId",
                table: "FundTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FundTransaction_MFundId",
                table: "FundTransaction",
                column: "MFundId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundTransaction_MFundFlowType_MFundFlowTypeId",
                table: "FundTransaction",
                column: "MFundFlowTypeId",
                principalTable: "MFundFlowType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundTransaction_MFund_MFundId",
                table: "FundTransaction",
                column: "MFundId",
                principalTable: "MFund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundTransaction_MFundFlowType_MFundFlowTypeId",
                table: "FundTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_FundTransaction_MFund_MFundId",
                table: "FundTransaction");

            migrationBuilder.DropIndex(
                name: "IX_FundTransaction_MFundId",
                table: "FundTransaction");

            migrationBuilder.RenameColumn(
                name: "MFundFlowTypeId",
                table: "FundTransaction",
                newName: "MFundFlowTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_FundTransaction_MFundFlowTypeId",
                table: "FundTransaction",
                newName: "IX_FundTransaction_MFundFlowTypeID");

            migrationBuilder.AlterColumn<int>(
                name: "MFundFlowTypeID",
                table: "FundTransaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FundFlowTypeId",
                table: "FundTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FundSummary_MFundId",
                table: "FundSummary",
                column: "MFundId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundSummary_MFund_MFundId",
                table: "FundSummary",
                column: "MFundId",
                principalTable: "MFund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundTransaction_MFundFlowType_MFundFlowTypeID",
                table: "FundTransaction",
                column: "MFundFlowTypeID",
                principalTable: "MFundFlowType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
