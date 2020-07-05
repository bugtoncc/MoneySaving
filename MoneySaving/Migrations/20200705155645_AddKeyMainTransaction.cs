using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class AddKeyMainTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMap_MCategory_MCategoryID",
                table: "CategoryMap");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMap_MPocket_MPocketID",
                table: "CategoryMap");

            migrationBuilder.RenameColumn(
                name: "MPocketID",
                table: "CategoryMap",
                newName: "MPocketId");

            migrationBuilder.RenameColumn(
                name: "MCategoryID",
                table: "CategoryMap",
                newName: "MCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMap_MPocketID",
                table: "CategoryMap",
                newName: "IX_CategoryMap_MPocketId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMap_MCategoryID",
                table: "CategoryMap",
                newName: "IX_CategoryMap_MCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryMapId",
                table: "MainTransaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_CategoryMapId",
                table: "MainTransaction",
                column: "CategoryMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMap_MCategory_MCategoryId",
                table: "CategoryMap",
                column: "MCategoryId",
                principalTable: "MCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMap_MPocket_MPocketId",
                table: "CategoryMap",
                column: "MPocketId",
                principalTable: "MPocket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_CategoryMap_CategoryMapId",
                table: "MainTransaction",
                column: "CategoryMapId",
                principalTable: "CategoryMap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMap_MCategory_MCategoryId",
                table: "CategoryMap");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMap_MPocket_MPocketId",
                table: "CategoryMap");

            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_CategoryMap_CategoryMapId",
                table: "MainTransaction");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_CategoryMapId",
                table: "MainTransaction");

            migrationBuilder.DropColumn(
                name: "CategoryMapId",
                table: "MainTransaction");

            migrationBuilder.RenameColumn(
                name: "MPocketId",
                table: "CategoryMap",
                newName: "MPocketID");

            migrationBuilder.RenameColumn(
                name: "MCategoryId",
                table: "CategoryMap",
                newName: "MCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMap_MPocketId",
                table: "CategoryMap",
                newName: "IX_CategoryMap_MPocketID");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMap_MCategoryId",
                table: "CategoryMap",
                newName: "IX_CategoryMap_MCategoryID");

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
    }
}
