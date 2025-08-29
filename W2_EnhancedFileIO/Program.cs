namespace W2_EnhancedFileIO;

class Program
{

    static void Main(string[] args)
    {
        var dataManager = new DataManager();
        dataManager.Read();
        DisplayMenu();

        List<string> MyList = new List<string>();
        MyList.Add("Jim1");
        MyList.Add("Jim2");
        MyList.Add("Jim3");
        MyList.Add("Jim4");
        MyList.Add("Jim5");
        MyList.Add("Jim6");
        MyList.Remove("Jim2");

        var userInput = Console.ReadLine();
        Console.WriteLine($"You chose: {userInput}");

        if (userInput == "1")
        {
            // Display characters
            foreach (var line in dataManager.FileContents)
            {
                var cols = line.Split(",");

                var name = cols[0];
                var profession = cols[1];
                var level = cols[2];
                var hp = cols[3];
                var equip = cols[4];

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
                Console.WriteLine($"Character name is {character.Name}");
            }
        }
        else if (userInput == "2")
        {
            // Add character
            var newCharacter = new Character();
            newCharacter.Name = "Morty";
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

    }
    static void DisplayMenu()
    {
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");
        Console.Write("> ");
    }
}

