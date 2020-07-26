using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class AddedUserColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MPocket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MainTransaction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MPocket_UserId",
                table: "MPocket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MCategory_UserId",
                table: "MCategory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_UserId",
                table: "MainTransaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_AspNetUsers_UserId",
                table: "MainTransaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MCategory_AspNetUsers_UserId",
                table: "MCategory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MPocket_AspNetUsers_UserId",
                table: "MPocket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_AspNetUsers_UserId",
                table: "MainTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_MCategory_AspNetUsers_UserId",
                table: "MCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MPocket_AspNetUsers_UserId",
                table: "MPocket");

            migrationBuilder.DropIndex(
                name: "IX_MPocket_UserId",
                table: "MPocket");

            migrationBuilder.DropIndex(
                name: "IX_MCategory_UserId",
                table: "MCategory");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_UserId",
                table: "MainTransaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MPocket");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MCategory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MainTransaction");
        }
    }
}
