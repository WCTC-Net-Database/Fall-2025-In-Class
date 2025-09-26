using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace W6_SOLID_DIP;

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

        //ICalculate calculate = new Calculate();
        //IMainService service = new MainService(calculate);

        //var isTrue = service.Execute();  

        //Console.WriteLine($"Service executed: {isTrue}");
    }
}

