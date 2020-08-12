using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class EditcolumnDailyNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyNav_MFund_MFundID",
                table: "DailyNav");

            migrationBuilder.DropColumn(
                name: "FundPortId",
                table: "DailyNav");

            migrationBuilder.RenameColumn(
                name: "MFundID",
                table: "DailyNav",
                newName: "MFundId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyNav_MFundID",
                table: "DailyNav",
                newName: "IX_DailyNav_MFundId");

            migrationBuilder.AlterColumn<int>(
                name: "MFundId",
                table: "DailyNav",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyNav_MFund_MFundId",
                table: "DailyNav",
                column: "MFundId",
                principalTable: "MFund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyNav_MFund_MFundId",
                table: "DailyNav");

            migrationBuilder.RenameColumn(
                name: "MFundId",
                table: "DailyNav",
                newName: "MFundID");

            migrationBuilder.RenameIndex(
                name: "IX_DailyNav_MFundId",
                table: "DailyNav",
                newName: "IX_DailyNav_MFundID");

            migrationBuilder.AlterColumn<int>(
                name: "MFundID",
                table: "DailyNav",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FundPortId",
                table: "DailyNav",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyNav_MFund_MFundID",
                table: "DailyNav",
                column: "MFundID",
                principalTable: "MFund",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
