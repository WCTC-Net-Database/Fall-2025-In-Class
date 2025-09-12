namespace W4_SOLID_OCP
{
    internal interface ICar
    {
        void Drive();
        bool StartEngine(IKeyFob keyFob);
    }

    public interface IKeyFob { }

    public class FakeKeyFob : IKeyFob { }

    public class Ford : ICar
    {
        public void Drive()
        {
            throw new NotImplementedException();
        }

        public bool StartEngine(IKeyFob keyFob)
        {
            throw new NotImplementedException();
        }
    }
}