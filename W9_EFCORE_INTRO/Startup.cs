using Microsoft.Extensions.DependencyInjection;

namespace W9_EFCORE_INTRO;

public static class Startup
{
    public static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Register services and dependencies
        services.AddTransient<IMainService, MainService>();
        services.AddSingleton<Program>();

        return services;
    }
}

