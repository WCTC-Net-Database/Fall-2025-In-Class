namespace W2_EnhancedFileIO;

class Program
{

    static void Main(string[] args)
    {
        var dataManager = new DataManager();
        dataManager.Read();
        DisplayMenu();

        var userInput = Console.ReadLine();
        Console.WriteLine($"You chose: {userInput}");

        if (userInput == "1")
        {
            // Display characters
            foreach (var line in dataManager.FileContents)
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

                //character.DisplayCharacter(character);

                Console.WriteLine($"Character is {character}");

            }
        }
        else if (userInput == "2")
        {
            // Add character
            var newCharacter = new Character();
            newCharacter.Name = "Morty, Sir";
            newCharacter.Profession = "Fighter";
            newCharacter.Level = 2;
            newCharacter.HitPoints = 12;
            newCharacter.Equipment.Add("mace");
            newCharacter.Equipment.Add("sword");
            newCharacter.Equipment.Add("backpack");

            dataManager.Write(newCharacter);

        }
        else if (userInput == "3")
        {
            // Level up character
        }
        else if (userInput == "4")
        {
            // Find character
            var results = dataManager.FileContents.OrderByDescending(c=>c);

            //Console.WriteLine(results);
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }

    }

    //public static bool FindName(string nameToFind)
    //{
    //    if (nameToFind.Contains("Bob, Sneaky"))
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    static void DisplayMenu()
    {
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");
        Console.WriteLine("4. Find Character");
        Console.Write("> ");
    }
}

