using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class AddedAmountInMainTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "MainTransaction",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MainTransaction");
        }
    }
}
