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
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpeciesName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
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
                    Alignment = table.Column<string>(type: "text", nullable: true),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Persons_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
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
                    { 15, "Horse", "General", false, false, "Copper", "1500" },
                    { 14, "Flute", "General", false, false, "Copper", "75" },
                    { 13, "Play card", "General", false, false, "Copper", "150" },
                    { 12, "Disquise Kit", "General", false, false, "Copper", "500" },
                    { 11, "Ration", "General", false, false, "Copper", "5" },
                    { 10, "shield", "Armor", false, false, "Copper", "100" },
                    { 9, "Plate", "Armor", false, false, "Copper", "15510" },
                    { 7, "Studded leather", "Armor", false, false, "Copper", "510" },
                    { 6, "padded", "Armor", false, false, "Copper", "150" },
                    { 5, "Longsword", "Weapon", false, false, "Copper", "5" },
                    { 4, "Battleaxe", "Weapon", false, false, "Copper", "65" },
                    { 3, "Greatsword", "Weapon", false, false, "Copper", "150" },
                    { 2, "Shortbow", "Weapon", false, false, "Copper", "75" },
                    { 8, "Half Plate", "Armor", false, false, "Copper", "1550" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "SpeciesName" },
                values: new object[,]
                {
                    { 2, "Human" },
                    { 1, "Elf" },
                    { 3, "Orc" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SpeciesId",
                table: "Persons",
                column: "SpeciesId");
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

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
