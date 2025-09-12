using Newtonsoft.Json;

namespace W4_SOLID_OCP
{
    public class JsonDataManager : DataManager, IDataManager
    {
        // default constructor
        public JsonDataManager()
        {
            FileName = "Files/input.json";
        }

        public void Read() 
        {
            var json = File.ReadAllText(FileName);
            var character = JsonConvert.DeserializeObject<List<Character>>(json);

            Characters.AddRange(character);
        }

        public void Write(Character character)
        { 
        
        }
    }
}
