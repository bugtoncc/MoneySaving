using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneySaving.Migrations
{
    public partial class RevertAddMCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MCategoryName",
                table: "CategoryMap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MCategoryName",
                table: "CategoryMap",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
