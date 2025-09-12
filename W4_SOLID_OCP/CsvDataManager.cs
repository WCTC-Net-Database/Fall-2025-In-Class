namespace W4_SOLID_OCP
{

    public class CsvDataManager : DataManager, IDataManager
    {
        public CsvDataManager()
        {
            FileName = "Files/input.csv";
        }
        public void Read()
        {
            using (StreamReader reader = new StreamReader(FileName))
            {
                reader.ReadLine();
                var line = reader.ReadLine();

                while (line != null)
                {
                    string name = null;
                    string restOfLine = line;

                    if (line.IndexOf('"') >= 0)
                    {
                        var remainder = line.TrimStart('"'); // remove leading quote
                        var quoteIndex = remainder.IndexOf('"'); // find next quote
                        name = remainder.Substring(0, quoteIndex); // extract name
                        restOfLine = remainder.Substring(quoteIndex + 2); // skip quote and comma
                    }
                    var cols = restOfLine.Split(",");

                    var profession = cols[0];
                    var level = cols[1];
                    var hp = cols[2];
                    var equip = cols[3];

                    var character = new Character();
                    character.Name = name;
                    character.Profession = profession;
                    character.Level = int.Parse(level);
                    character.HitPoints = int.Parse(hp);

                    var equipment = equip.Split("|");
                    foreach (var eq in equipment)
                    {
                        character.Equipment.Add(eq);
                    }

                    Characters.Add(character);

                    line = reader.ReadLine();
                }
            }
        }

        public void Write(Character character)
        {
            Characters.Add(character);
        }

        public void SaveChanges()
        {
            using (StreamWriter writer = new StreamWriter(FileName))
            {
                writer.WriteLine("Name,Profession,Level,HitPoints,Equipment");
                foreach (var character in Characters)
                {
                    var equipment = string.Join("|", character.Equipment);
                    var line = $"\"{character.Name}\",{character.Profession},{character.Level},{character.HitPoints},{equipment}";
                    writer.WriteLine(line);
                }
            }
        }

    }
}
