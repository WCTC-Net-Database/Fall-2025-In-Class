using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using W10_EFCORE_TPH.Models;

#nullable disable

namespace W9_EFCORE_INTRO.Migrations
{
    /// <inheritdoc />
    public partial class SeedMonsters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Monsters] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[Monsters]([Id], [Name], [HitPoints], [MonsterType], [Gold], [Attack], [Defense], [Regenerate]) VALUES(1, N'Gobbo', 30, N'Goblin', 7, 5, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Monsters] ([Id], [Name], [HitPoints], [MonsterType], [Gold], [Attack], [Defense], [Regenerate]) VALUES(2, N'Trolly', 80, N'Troll', NULL, NULL, 10, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Monsters]([Id], [Name], [HitPoints], [MonsterType], [Gold], [Attack], [Defense], [Regenerate]) VALUES(3, N'Bobbo', 30, N'Goblin', 3, 8, NULL, NULL)");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Monsters] OFF");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Monsters] WHERE [Id] IN (1, 2, 3)");
        }
    }
}
