using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class RemoveCatagoryMapTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_CategoryMap_CategoryMapId",
                table: "MainTransaction");

            migrationBuilder.DropTable(
                name: "CategoryMap");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_CategoryMapId",
                table: "MainTransaction");

            migrationBuilder.DropColumn(
                name: "CategoryMapId",
                table: "MainTransaction");

            migrationBuilder.AddColumn<int>(
                name: "MCategoryId",
                table: "MainTransaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MpocketId",
                table: "MainTransaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_MCategoryId",
                table: "MainTransaction",
                column: "MCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_MpocketId",
                table: "MainTransaction",
                column: "MpocketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_MCategory_MCategoryId",
                table: "MainTransaction",
                column: "MCategoryId",
                principalTable: "MCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_MPocket_MpocketId",
                table: "MainTransaction",
                column: "MpocketId",
                principalTable: "MPocket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_MCategory_MCategoryId",
                table: "MainTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_MainTransaction_MPocket_MpocketId",
                table: "MainTransaction");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_MCategoryId",
                table: "MainTransaction");

            migrationBuilder.DropIndex(
                name: "IX_MainTransaction_MpocketId",
                table: "MainTransaction");

            migrationBuilder.DropColumn(
                name: "MCategoryId",
                table: "MainTransaction");

            migrationBuilder.DropColumn(
                name: "MpocketId",
                table: "MainTransaction");

            migrationBuilder.AddColumn<int>(
                name: "CategoryMapId",
                table: "MainTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryMap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MCategoryId = table.Column<int>(type: "int", nullable: false),
                    MPocketId = table.Column<int>(type: "int", nullable: false),
                    StatusFlag = table.Column<bool>(type: "bit", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryMap_MCategory_MCategoryId",
                        column: x => x.MCategoryId,
                        principalTable: "MCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMap_MPocket_MPocketId",
                        column: x => x.MPocketId,
                        principalTable: "MPocket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainTransaction_CategoryMapId",
                table: "MainTransaction",
                column: "CategoryMapId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMap_MCategoryId",
                table: "CategoryMap",
                column: "MCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMap_MPocketId",
                table: "CategoryMap",
                column: "MPocketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainTransaction_CategoryMap_CategoryMapId",
                table: "MainTransaction",
                column: "CategoryMapId",
                principalTable: "CategoryMap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
