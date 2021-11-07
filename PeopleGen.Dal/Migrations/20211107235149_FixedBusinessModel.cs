using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleGen.Dal.Migrations
{
    public partial class FixedBusinessModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_Civilization_CivilizationCityId",
                table: "Business");

            migrationBuilder.AlterColumn<int>(
                name: "CivilizationCityId",
                table: "Business",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Business_Civilization_CivilizationCityId",
                table: "Business",
                column: "CivilizationCityId",
                principalTable: "Civilization",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_Civilization_CivilizationCityId",
                table: "Business");

            migrationBuilder.AlterColumn<int>(
                name: "CivilizationCityId",
                table: "Business",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_Civilization_CivilizationCityId",
                table: "Business",
                column: "CivilizationCityId",
                principalTable: "Civilization",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
