using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class AddKeyCategoryMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MCategoryID",
                table: "CategoryMap",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MPocketID",
                table: "CategoryMap",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMap_MCategoryID",
                table: "CategoryMap",
                column: "MCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMap_MPocketID",
                table: "CategoryMap",
                column: "MPocketID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMap_MCategory_MCategoryID",
                table: "CategoryMap",
                column: "MCategoryID",
                principalTable: "MCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMap_MPocket_MPocketID",
                table: "CategoryMap",
                column: "MPocketID",
                principalTable: "MPocket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMap_MCategory_MCategoryID",
                table: "CategoryMap");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMap_MPocket_MPocketID",
                table: "CategoryMap");

            migrationBuilder.DropIndex(
                name: "IX_CategoryMap_MCategoryID",
                table: "CategoryMap");

            migrationBuilder.DropIndex(
                name: "IX_CategoryMap_MPocketID",
                table: "CategoryMap");

            migrationBuilder.DropColumn(
                name: "MCategoryID",
                table: "CategoryMap");

            migrationBuilder.DropColumn(
                name: "MPocketID",
                table: "CategoryMap");
        }
    }
}
