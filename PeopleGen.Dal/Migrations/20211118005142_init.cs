using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PeopleGen.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Civilization",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    TypeOfRule = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Ideology = table.Column<string>(type: "text", nullable: true)
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
                    MoneyType = table.Column<string>(type: "text", nullable: false),
                    IsMagical = table.Column<bool>(type: "boolean", nullable: false),
                    IsCursed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false),
                    Alignment = table.Column<string>(type: "text", nullable: false),
                    PersonalityStrength = table.Column<string>(type: "text", nullable: true),
                    SpeciesName = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Civilization_CityId",
                        column: x => x.CityId,
                        principalTable: "Civilization",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessName = table.Column<string>(type: "text", nullable: false),
                    BusinessType = table.Column<string>(type: "text", nullable: false),
                    BusinessOwnerPersonId = table.Column<int>(type: "integer", nullable: true),
                    NumOfEmployees = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    CivilizationCityId = table.Column<int>(type: "integer", nullable: true),
                    InventoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Business_Civilization_CivilizationCityId",
                        column: x => x.CivilizationCityId,
                        principalTable: "Civilization",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Persons_BusinessOwnerPersonId",
                        column: x => x.BusinessOwnerPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryId", "InventoryName", "InventoryType", "IsCursed", "IsMagical", "MoneyType", "Price" },
                values: new object[,]
                {
                    { 1, "Sickle", "Weapon", false, false, "Copper", "50" },
                    { 2, "Shortbow", "Weapon", false, false, "Copper", "75" },
                    { 3, "Greatsword", "Weapon", false, false, "Copper", "150" },
                    { 4, "Battleaxe", "Weapon", false, false, "Copper", "65" },
                    { 5, "Longsword", "Weapon", false, false, "Copper", "5" },
                    { 6, "padded", "Armor", false, false, "Copper", "150" },
                    { 7, "Studded leather", "Armor", false, false, "Copper", "510" },
                    { 8, "Half Plate", "Armor", false, false, "Copper", "1550" },
                    { 9, "Plate", "Armor", false, false, "Copper", "15510" },
                    { 10, "shield", "Armor", false, false, "Copper", "100" },
                    { 11, "Ration", "General", false, false, "Copper", "5" },
                    { 12, "Disquise Kit", "General", false, false, "Copper", "500" },
                    { 13, "Play card", "General", false, false, "Copper", "150" },
                    { 14, "Flute", "General", false, false, "Copper", "75" },
                    { 15, "Horse", "General", false, false, "Copper", "1500" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessOwnerPersonId",
                table: "Business",
                column: "BusinessOwnerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CivilizationCityId",
                table: "Business",
                column: "CivilizationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_InventoryId",
                table: "Business",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Civilization");
        }
    }
}
