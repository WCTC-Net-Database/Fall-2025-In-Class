using Microsoft.EntityFrameworkCore.Migrations;

namespace W11_EFCORE_ABSTRACT.Migrations
{
    public abstract class BaseMigration : Migration
    {
        protected void RunSql(MigrationBuilder migrationBuilder)
        {
            var migrationName = GetType().Name;
            var sqlFile = $"Migrations/Scripts/{migrationName}.sql";
            var sql = File.ReadAllText(sqlFile);
            migrationBuilder.Sql(sql);

        }

        protected void RunSqlRollback(MigrationBuilder migrationBuilder)
        {
            var migrationName = GetType().Name;
            var sqlFile = $"Migrations/Scripts/{migrationName}.rollback.sql";
            var sql = File.ReadAllText(sqlFile);
            migrationBuilder.Sql(sql);
        }

    }
}
