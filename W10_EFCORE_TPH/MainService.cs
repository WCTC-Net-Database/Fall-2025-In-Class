using W9_EFCORE_INTRO.Data;
using W9_EFCORE_INTRO.Models;

namespace W9_EFCORE_INTRO
{
    public class MainService : IMainService
    {
        private readonly GameContext _context;

        public MainService(GameContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            Console.WriteLine("Entering MainService");

            //var context = new GameContext();
            _context.Seed();

            // Add a new room to the database
            var newRoom = new Room
            {
                Name = "Dungeon",
                Description = "A dark, damp dungeon with chains hanging from the walls."
            };
            _context.Rooms.Add(newRoom);

            // Add a new character to the database
            var newCharacter = new Character
            {
                Name = "Gorak the Fierce",
                Level = 10
                //Room = newRoom 
            };
            _context.Characters.Add(newCharacter);


            // Find a character by name
            var foundCharacter = _context.Characters.FirstOrDefault(character => character.Name.Contains("Aria"));
            Console.WriteLine($"Found character: {foundCharacter!.Name}, Level: {foundCharacter.Level}");


            // Not part of the assignment, but showing how to update
            // Delete a character by name
            var characterToDelete = _context.Characters.FirstOrDefault(character => character.Name.Contains("Luna"));
            _context.Characters.Remove(characterToDelete);
            Console.WriteLine($"Deleted character: {characterToDelete.Name}");

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // !!!! REMEMBER TO SAVE CHANGES !!!! 
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _context.SaveChanges();
        }
    }
}
