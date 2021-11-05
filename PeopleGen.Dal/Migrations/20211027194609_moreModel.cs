using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PeopleGen.Dal.Migrations
{
    public partial class moreModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CivilizationCityId",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessName = table.Column<string>(type: "text", nullable: false),
                    BusinessType = table.Column<string>(type: "text", nullable: false),
                    BusinessOwnerPersonId = table.Column<int>(type: "integer", nullable: true),
                    NumOfEmployees = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Business_Persons_BusinessOwnerPersonId",
                        column: x => x.BusinessOwnerPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Civilization",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    TypeOfRule = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Ideology = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civilization", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryName = table.Column<string>(type: "text", nullable: false),
                    InventoryType = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false),
                    moneyType = table.Column<string>(type: "text", nullable: false),
                    IsMagical = table.Column<bool>(type: "boolean", nullable: false),
                    IsCursed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessInventory",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "integer", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessInventory", x => new { x.BusinessId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_BusinessInventory_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessInventory_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CivilizationCityId",
                table: "Persons",
                column: "CivilizationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessOwnerPersonId",
                table: "Business",
                column: "BusinessOwnerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessInventory_InventoryId",
                table: "BusinessInventory",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Civilization_CivilizationCityId",
                table: "Persons",
                column: "CivilizationCityId",
                principalTable: "Civilization",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Civilization_CivilizationCityId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "BusinessInventory");

            migrationBuilder.DropTable(
                name: "Civilization");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CivilizationCityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CivilizationCityId",
                table: "Persons");
        }
    }
}
