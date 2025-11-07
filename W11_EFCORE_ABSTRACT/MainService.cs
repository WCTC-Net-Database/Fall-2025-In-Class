using W11_EFCORE_ABSTRACT.Data;
using W11_EFCORE_ABSTRACT.Models;

namespace W11_EFCORE_ABSTRACT
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

            //var monsters = _context.Monsters;
            //foreach (var monster in monsters)
            //{
            //    Console.WriteLine($"Monster: {monster.Name}");
            //}

            // Create a new character
            //var newCharacter = new Character
            //{
            //    Name = "Aragorn",
            //    Level = 10,
            //    Equipment = new Equipment()
            //};
            //_context.Characters.Add(newCharacter);

            var player = _context.Characters.Where(c => c.Name == "Aragorn").FirstOrDefault();

            // Find a sword in the Items table
            //var sword = _context.Items.OfType<Weapon>().Where(i => i.Name.Contains("Sword")).FirstOrDefault();
            //var armor = _context.Items.OfType<Armor>().Where(i => i.Name.Contains("Armor")).FirstOrDefault();
            //player.AddItem(sword);
            //player.AddItem(armor);

            // allow the player to choose an item they have in their inventory to equip
            
            player!.ListItems();
            var sword = player.Items.OfType<Weapon>().First();

            // try to equip the sword

            //player.Equipment.TryEquip(sword);

            //player.Equipment.EquipArmor(sword);

            player.ListEquipment();

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //  SAVE CHANGES TO THE DATABASE
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _context.SaveChanges();

        }
    }
}
