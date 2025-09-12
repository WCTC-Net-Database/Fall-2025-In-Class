namespace W4_SOLID_OCP
{
    public interface IDataManager
    {
        void Read();
        void Write(Character c);

        List<Character> Characters { get; set;}
    }
}
