namespace W4_SOLID_OCP;

class Program
{

    static void Main(string[] args)
    {
        // new phone program
        IPhone phone;
        // menu 1
        phone.MakeCall("111-222-3333");
        // menu 2
        phone.TakePicture();

        phone.PlayGame();

        ICar car = new Ford();
        RealKeyFob keyFob;
        bool didStart = car.StartEngine(keyFob);
        car.Drive();

        //var jsonManager = new JsonDataManager();
        //jsonManager.ReadJson();
        //foreach (var character in jsonManager.Characters)
        //{
        //    Console.WriteLine(character);
        //}
        //return;

        // Load the data
        IDataManager context = new JsonDataManager();
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

