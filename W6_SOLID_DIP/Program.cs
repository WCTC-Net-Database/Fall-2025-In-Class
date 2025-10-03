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

        Console.WriteLine("Enter a number");
        int? value1 = Convert.ToInt32(Console.ReadLine() ?? null);
        Console.WriteLine("Enter another number");
        int? value2 = Convert.ToInt32(Console.ReadLine() ?? null);

        var myStr = value1?.ToString();

        int num1 = int.Parse(value1);
        var isInt = int.TryParse(value2, out int num2);
        if (isInt == false)
        {
            Console.WriteLine("You did not enter a valid number");
            return;
        }

        var answer = num1 + num2;
        Console.WriteLine($"Your answer is {answer}");

        //ICalculate calculate = new Calculate();
        //IMainService service = new MainService(calculate);

        //var isTrue = service.Execute();  

        //Console.WriteLine($"Service executed: {isTrue}");
    }
}

