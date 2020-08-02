using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Data.Migrations
{
    public partial class AddedPKfromAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "MFund",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UniqueId",
                table: "MAmc",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "MFund");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "MAmc");
        }
    }
}
