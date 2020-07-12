using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class AddedBalanceInMPocket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "MPocket",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "MPocket");
        }
    }
}
