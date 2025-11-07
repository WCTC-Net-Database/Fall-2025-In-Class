using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9_EFCORE_INTRO.Migrations
{
    /// <inheritdoc />
    public partial class AddMonsterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    MonsterType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Regenerate = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
