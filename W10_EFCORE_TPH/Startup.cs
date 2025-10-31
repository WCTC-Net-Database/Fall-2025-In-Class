using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Proxies;
using W9_EFCORE_INTRO.Data;

namespace W9_EFCORE_INTRO;

public static class Startup
{
    public static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Register services and dependencies
        services.AddTransient<IMainService, MainService>();
        services.AddSingleton<Program>();

        // Load the configuration from appsettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();

        // Use the configuration to set up the DbContext
        services.AddDbContext<GameContext>(options =>
            options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies()
        );

        return services;

    }
}

