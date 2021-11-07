using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleGen.Dal.Migrations
{
    public partial class CorrectTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "moneyType",
                table: "Inventory",
                newName: "MoneyType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoneyType",
                table: "Inventory",
                newName: "moneyType");
        }
    }
}
