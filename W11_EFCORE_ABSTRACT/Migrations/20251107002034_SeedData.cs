using Microsoft.EntityFrameworkCore.Migrations;
using W11_EFCORE_ABSTRACT.Migrations;

#nullable disable

namespace W9_EFCORE_INTRO.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : BaseMigration
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
