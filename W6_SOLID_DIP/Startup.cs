using Microsoft.Extensions.DependencyInjection;

namespace W6_SOLID_DIP;

public static class Startup
{
    public static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Register services and dependencies
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<ICalculate, Calculate>();
        services.AddTransient<IFindService, FindService>();
        services.AddSingleton<Program>();

        return services;
    }
}

