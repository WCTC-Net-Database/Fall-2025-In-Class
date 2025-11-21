using System;

// ---------------------------------------------------------
// 1. SETUP - Create the World
// ---------------------------------------------------------

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

// ---------------------------------------------------------
// 2. GAME LOOP
// ---------------------------------------------------------

Room currentRoom = entrance;
bool gameRunning = true;

Console.WriteLine("Welcome to the Dungeon Explorer!");
Console.WriteLine("Find the room named 'Exit' to win.\n");

while (gameRunning)
{
    // Check win condition
    if (currentRoom.Name.Equals("Exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"*** {currentRoom.Name} ***");
        Console.WriteLine(currentRoom.Desc);
        Console.WriteLine("\nCONGRATULATIONS! You have found the way out.");
        Console.ResetColor();
        gameRunning = false;
        break;
    }

    // --- STEP 1: Display Room Details ---
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"--- {currentRoom.Name} ---");
    Console.ResetColor();
    Console.WriteLine(currentRoom.Desc);

    Console.Write("Exits available: ");
    Console.ForegroundColor = ConsoleColor.Yellow;

    // Helper logic to show only valid directions
    if (currentRoom.North != null) Console.Write("[N]orth ");
    if (currentRoom.South != null) Console.Write("[S]outh ");
    if (currentRoom.East != null) Console.Write("[E]ast ");
    if (currentRoom.West != null) Console.Write("[W]est ");

    Console.ResetColor();
    Console.WriteLine("\n");

    // --- STEP 2: Menu / Move ---
    Console.Write("Which direction do you want to go? > ");
    string? input = Console.ReadLine()?.Trim().ToLower();

    Console.WriteLine(); // Spacer

    switch (input)
    {
        case "n":
        case "north":
            if (currentRoom.North != null) currentRoom = currentRoom.North;
            else InvalidMove();
            break;

        case "s":
        case "south":
            if (currentRoom.South != null) currentRoom = currentRoom.South;
            else InvalidMove();
            break;

        case "e":
        case "east":
            if (currentRoom.East != null) currentRoom = currentRoom.East;
            else InvalidMove();
            break;

        case "w":
        case "west":
            if (currentRoom.West != null) currentRoom = currentRoom.West;
            else InvalidMove();
            break;

        default:
            Console.WriteLine("I don't understand that command. Try 'North', 'South', 'East', or 'West'.");
            break;
    }
}

// Helper to keep code clean
void InvalidMove()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("You can't go that way! There is a wall there.");
    Console.ResetColor();
}

// ---------------------------------------------------------
// 3. CLASS DEFINITION
// ---------------------------------------------------------

class Room
{
    public string Name { get; set; }
    public string Desc { get; set; }

    // Nullable (?) because a room might not have a connection in that direction
    public Room? North { get; set; }
    public Room? South { get; set; }
    public Room? West { get; set; }
    public Room? East { get; set; }

    public Room(string name, string desc)
    {
        Name = name;
        Desc = desc;
    }
}