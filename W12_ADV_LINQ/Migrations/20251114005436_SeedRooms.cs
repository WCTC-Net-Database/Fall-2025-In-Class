using Microsoft.EntityFrameworkCore.Migrations;
using W12_ADV_LINQ.Migrations;

#nullable disable

namespace W9_EFCORE_INTRO.Migrations
{
    /// <inheritdoc />
    public partial class SeedRooms : BaseMigration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            RunSql(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            RunSqlRollback(migrationBuilder);
        }
    }
}
