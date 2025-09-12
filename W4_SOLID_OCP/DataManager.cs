namespace W4_SOLID_OCP
{
    public class DataManager
    {
        public string FileName { get; set; }
        public List<Character> Characters { get; set; }
        public DataManager()
        {
            Characters = new List<Character>();
        }
    }
}
