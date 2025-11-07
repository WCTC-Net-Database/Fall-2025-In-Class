using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace W11_EFCORE_ABSTRACT.Data
{
    // Design-time factory for GameContext
    // NOT USED AT RUNTIME
    // Used for EF Core tools like EF migrations (dotnet ef ...)
    public class GameContextFactory : IDesignTimeDbContextFactory<GameContext>
    {
        public GameContext CreateDbContext(string[] args)
        {
            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Build DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<GameContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Create and return the context
            return new GameContext(optionsBuilder.Options);
        }
    }
}
