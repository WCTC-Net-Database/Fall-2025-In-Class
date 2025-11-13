using Microsoft.Extensions.DependencyInjection;

namespace W12_ADV_LINQ;

public class Program
{
    private IMainService _mainService;

    public Program(IMainService mainService)
    {
        _mainService = mainService;
    }
    public void Run()
    {
        Console.WriteLine("Program is running...");
        _mainService.Execute();
    }
    public static void Main(string[] args)
    {
        var serviceCollection = Startup.ConfigureServices();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var program = serviceProvider.GetService<Program>();
        program?.Run();
    }
}

