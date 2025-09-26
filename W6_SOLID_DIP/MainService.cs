using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6_SOLID_DIP
{
    public class MainService : IMainService
    {
        private readonly ICalculate _calculate;
        private readonly IFindService _findService;

        public MainService(ICalculate calculate, IFindService findService)
        {
            _calculate = calculate;
            _findService = findService;
        }

        public bool Execute()
        {
            Console.WriteLine("MainService is executing...");

            var result = _findService.FindSum(3,4);
            Console.WriteLine($"FindService found sum: {result}");

            return Add(1,2) == 3;
        }

        private int Add(int x, int y)
        {
            // new Calculate();
            return _calculate.Add(x,y);
        }
    }
    public interface IMainService
    {
        bool Execute();
    }

}
