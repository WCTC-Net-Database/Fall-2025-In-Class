namespace W2_EnhancedFileIO
{

    public class DataManager
    {
        public List<string> FileContents { get; set; }

        private string _fileName = "input.csv";

        public DataManager()
        {
            FileContents = new List<string>();
        }

        public void Read()
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                reader.ReadLine();
                var line = reader.ReadLine();

                while (line != null)
                {
                    FileContents.Add(line);
                    line = reader.ReadLine();
                }
            }
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
