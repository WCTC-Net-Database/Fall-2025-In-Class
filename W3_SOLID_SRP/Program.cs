namespace W2_EnhancedFileIO;

class Program
{

    static void Main(string[] args)
    {
        // Load the data
        var context = new DataContext();
        context.Read();

        // Display menu
        DisplayMenu();
        var userInput = Console.ReadLine();

        if (userInput == "1")
        {
            // Display characters
            foreach (var character in context.Characters)
            {
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

            context.Write(newCharacter);

        }
        else if (userInput == "3")
        {
            // Level up character
        }
        else if (userInput == "4")
        {
            // Find character
            //var results = dataManager.FileContents.OrderByDescending(c=>c);

            //Console.WriteLine(results);
            //foreach (var r in results)
            //{
            //    Console.WriteLine(r);
            //}
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

