using System.Data.Common;
using System.Reflection.Emit;

namespace W1_FileIO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");
        Console.Write("> ");

        var userInput = Console.ReadLine();
        Console.WriteLine($"You chose: {userInput}");

        if (userInput == "1")
        {
            var lines = File.ReadAllLines("input.csv");

            foreach (var line in lines)
            {
                var cols = line.Split(",");

                var name = cols[0];
                var profession = cols[1];
                var level = cols[2];
                var hp = cols[3];
                var equip = cols[4];

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Profession: {profession}");
                Console.WriteLine($"Level: {level}");
                Console.WriteLine($"HP: {hp}");

                var equipment = equip.Split("|");
                Console.WriteLine($"Equipment:");
                foreach (var eq in equipment)
                {
                    {
                        Console.WriteLine($"\t{eq}");
                    }
                }
                Console.WriteLine("--------------");

            }
        }
        else if (userInput == "2")
        {
            using (StreamWriter writer = new StreamWriter("input.csv", true))
            {
                var myUserData = "Morty,Fighter,2,12,mace|sword|backpack";
                writer.WriteLine(myUserData);
            }
        }
        else if (userInput=="3") 
            { }

    }
}
