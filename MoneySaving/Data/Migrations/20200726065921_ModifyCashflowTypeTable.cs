using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class ModifyCashflowTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "CashflowType");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CashflowType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashflowType_UserId",
                table: "CashflowType",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashflowType_AspNetUsers_UserId",
                table: "CashflowType",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashflowType_AspNetUsers_UserId",
                table: "CashflowType");

            migrationBuilder.DropIndex(
                name: "IX_CashflowType_UserId",
                table: "CashflowType");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CashflowType");

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "CashflowType",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
