using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9_EFCORE_INTRO.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterItem",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterItem", x => new { x.CharactersId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CharacterItem_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Items_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipments_Items_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItem_ItemsId",
                table: "CharacterItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ArmorId",
                table: "Equipments",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_WeaponId",
                table: "Equipments",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Equipments_EquipmentId",
                table: "Characters",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Equipments_EquipmentId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterItem");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Characters");
        }
    }
}
