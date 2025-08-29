namespace W2_EnhancedFileIO
{

    public class DataManager
    {
        public string[]? FileContents { get; set; }

        private string _fileName = "input.csv";

        public DataManager()
        {
            // Should we read in the file here?
        }
        public void Read()
        {
            FileContents = File.ReadAllLines(_fileName);
        }

        public void Write(Character character)
        {
            // append to the file
            using (StreamWriter writer = new StreamWriter(_fileName, true))
            {
            }
        }
    }
}
