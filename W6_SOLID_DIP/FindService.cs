using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6_SOLID_DIP
{
    public class FindService : IFindService
    {
        private readonly ICalculate _calculate;

        public FindService(ICalculate calculate)
        {
            _calculate = calculate;
        }

        public int FindSum(int a, int b)
        {
            return _calculate.Add(a, b);
        }
    }

    public interface IFindService
    {
        int FindSum(int a, int b);
    }
}
