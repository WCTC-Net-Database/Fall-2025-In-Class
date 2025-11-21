
using W13_ROOM_NAV.Models;

namespace W13_ROOM_NAV
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create the rooms
            Room entrance = new Room("Dungeon Entrance", "You are standing in a dark, cold cave entrance. Water drips from the ceiling.");
            Room greatHall = new Room("Great Hall", "A massive stone room with high ceilings. Banners hang tattered on the walls.");
            Room kitchen = new Room("Abandoned Kitchen", "Pots and pans are scattered everywhere. A faint smell of rot lingers.");
            Room cellar = new Room("Damp Cellar", "It is pitch black and smells of mold. You hear skittering sounds.");
            Room library = new Room("Ancient Library", "Dusty bookshelves line the walls. Most books have turned to dust.");
            Room hiddenLab = new Room("Hidden Laboratory", "Glass vials and strange machines sit on tables. Ideally, this shouldn't be here.");
            Room courtyard = new Room("Overgrown Courtyard", "You are outside, but surrounded by high walls. Vines cover everything.");
            Room guardPost = new Room("Guard Post", "An empty checkpoint. A rusted spear leans against the wall.");
            Room exit = new Room("Exit", "The heavy iron gates are open! Freedom awaits.");

            // Link the rooms together to create the map
            // Entrance links
            entrance.North = greatHall;

            // Great Hall links
            greatHall.South = entrance;
            greatHall.West = kitchen;
            greatHall.East = library;
            greatHall.North = courtyard;

            // Kitchen links
            kitchen.East = greatHall;
            kitchen.South = cellar;

            // Cellar links
            cellar.North = kitchen;

            // Library links
            library.West = greatHall;
            library.North = hiddenLab;

            // Hidden Lab links
            hiddenLab.South = library;

            // Courtyard links
            courtyard.South = greatHall;
            courtyard.East = guardPost;

            // Guard Post links
            guardPost.West = courtyard;
            guardPost.North = exit;

            // Exit links
            exit.South = guardPost;

            var currentRoom = entrance;

            while (true)
            {
                if (currentRoom.Name.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Congratulations! You have found the exit and escaped the dungeon!");
                    break;
                }

                // display current room info
                Console.WriteLine($"\nYou are in the {currentRoom.Name}.");
                Console.WriteLine(currentRoom.Desc);
                Console.Write("Exits: ");

                if (currentRoom.North != null) Console.WriteLine("[N]orth");
                if (currentRoom.South != null) Console.WriteLine("[S]outh");
                if (currentRoom.East != null) Console.WriteLine("[E]ast");
                if (currentRoom.West != null) Console.WriteLine("[W]est");

                // solicit user input
                Console.Write("\nEnter direction (N/S/E/W)");
                var input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "n":
                        if (currentRoom.North != null) currentRoom = currentRoom.North;
                        else InvalidDirection();
                        break;
                    case "s":
                        if (currentRoom.South != null) currentRoom = currentRoom.South;
                        else InvalidDirection();
                        break;
                    case "e":
                        if (currentRoom.East != null) currentRoom = currentRoom.East;
                        else InvalidDirection();
                        break;
                    case "w":
                        if (currentRoom.West != null) currentRoom = currentRoom.West;
                        else InvalidDirection();
                        break;
                    default:
                        Console.WriteLine("Invalid direction. Please enter N, S, E, or W.");
                        break;

                }
            }
        }

        private static void InvalidDirection()
        {
            Console.WriteLine("You can't go that way.");
        }

    }
}