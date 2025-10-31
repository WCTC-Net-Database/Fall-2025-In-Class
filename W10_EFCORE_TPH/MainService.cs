using W10_EFCORE_TPH.Models;
using W9_EFCORE_INTRO.Data;
using W9_EFCORE_INTRO.Models;

namespace W9_EFCORE_INTRO
{
    public class MainService : IMainService, IDisposable
    {
        private readonly GameContext _context;

        public MainService(GameContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Execute()
        {
            Console.WriteLine("Entering MainService");

            // List the Rooms
            var rooms = _context.Rooms;

            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {room.Name} - {room.Description}");
            }

            // Create some monsters
            //Monster goblin = new Goblin
            //{
            //    Name = "Gobbo",
            //    HitPoints = 30,
            //    Gold = 7,
            //    Attack = 5
            //};  

            //Monster troll = new Troll
            //{
            //    Name = "Trolly",
            //    HitPoints = 80,
            //    Defense = 10,
            //    Regenerate = true
            //};

            //_context.Monsters.Add(goblin);
            //_context.Monsters.Add(troll);

            var monsters = _context.Monsters;
            foreach (var monster in monsters)
            {
                Console.WriteLine($"Monster: {monster.Name}");
            }

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //  SAVE CHANGES TO THE DATABASE
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _context.SaveChanges();

        }
    }
}
