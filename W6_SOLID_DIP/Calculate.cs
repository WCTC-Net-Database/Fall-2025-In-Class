namespace W6_SOLID_DIP
{
    public class Calculate : ICalculate
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    public interface ICalculate
    {
        int Add(int a, int b);
    }
}