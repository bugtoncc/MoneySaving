using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class AddPKCashflowType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CashflowTypeId",
                table: "MCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MCategory_CashflowTypeId",
                table: "MCategory",
                column: "CashflowTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MCategory_CashflowType_CashflowTypeId",
                table: "MCategory",
                column: "CashflowTypeId",
                principalTable: "CashflowType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCategory_CashflowType_CashflowTypeId",
                table: "MCategory");

            migrationBuilder.DropIndex(
                name: "IX_MCategory_CashflowTypeId",
                table: "MCategory");

            migrationBuilder.DropColumn(
                name: "CashflowTypeId",
                table: "MCategory");
        }
    }
}
