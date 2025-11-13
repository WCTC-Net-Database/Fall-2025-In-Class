using Microsoft.EntityFrameworkCore;
using W12_ADV_LINQ.Data;
using W12_ADV_LINQ.Models;

namespace W12_ADV_LINQ
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
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         W12 - Advanced LINQ Demonstrations                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

            // Ensure we have data loaded with navigation properties
            var characters = _context.Characters
                .Include(c => c.Items)
                .Include(c => c.Equipment)
                    .ThenInclude(e => e!.Weapon)
                .Include(c => c.Equipment)
                    .ThenInclude(e => e!.Armor)
                .Include(c => c.Room)
                .ToList();

            var rooms = _context.Rooms
                .Include(r => r.Characters)
                .ToList();

            var monsters = _context.Monsters.ToList();

            // ================================================
            // Example 1: Basic Filtering and Projection
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 1: Basic Filtering - Characters Above Level 5");
            Console.WriteLine(new string('=', 60));

            var highLevelCharacters = _context.Characters
                .Where(c => c.Level > 5)
                .OrderByDescending(c => c.Level)
                .ToList();

            foreach (var character in highLevelCharacters)
            {
                Console.WriteLine($"  • {character.Name} (Level {character.Level})");
            }
            if (!highLevelCharacters.Any())
                Console.WriteLine("  No high-level characters found.");

            // ================================================
            // Example 2: Projection with Anonymous Types
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 2: Character Summary with Anonymous Types");
            Console.WriteLine(new string('=', 60));

            var characterSummary = _context.Characters
                .Select(c => new
                {
                    c.Name,
                    c.Level,
                    RoomName = c.Room != null ? c.Room.Name : "No Room",
                    ItemCount = c.Items.Count
                })
                .ToList();

            foreach (var summary in characterSummary)
            {
                Console.WriteLine($"  • {summary.Name} (Lvl {summary.Level}) - Room: {summary.RoomName}, Items: {summary.ItemCount}");
            }

            // ================================================
            // Example 3: Type Filtering with OfType
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 3: Filtering Items by Type (Weapons Only)");
            Console.WriteLine(new string('=', 60));

            var weapons = _context.Items
                .OfType<Weapon>()
                .OrderByDescending(w => w.Damage)
                .ToList();

            foreach (var weapon in weapons)
            {
                Console.WriteLine($"  • {weapon.Name} - Damage: {weapon.Damage}");
            }
            if (!weapons.Any())
                Console.WriteLine("  No weapons found.");

            // ================================================
            // Example 4: SelectMany - Flattening Collections
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 4: All Items with Their Owners (SelectMany)");
            Console.WriteLine(new string('=', 60));

            var itemsWithOwners = _context.Characters
                .SelectMany(c => c.Items, (character, item) => new
                {
                    CharacterName = character.Name,
                    ItemName = item.Name,
                    ItemType = item is Weapon ? "Weapon" : "Armor"
                })
                .ToList();

            foreach (var entry in itemsWithOwners.Take(10)) // Limit to first 10
            {
                Console.WriteLine($"  • {entry.CharacterName} owns {entry.ItemName} ({entry.ItemType})");
            }
            if (!itemsWithOwners.Any())
                Console.WriteLine("  No items found.");

            // ================================================
            // Example 5: Aggregation Operations
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 5: Aggregation - Statistics");
            Console.WriteLine(new string('=', 60));

            var totalCharacters = _context.Characters.Count();
            var averageLevel = _context.Characters.Any() ? _context.Characters.Average(c => c.Level) : 0;
            var maxLevel = _context.Characters.Any() ? _context.Characters.Max(c => c.Level) : 0;
            var minLevel = _context.Characters.Any() ? _context.Characters.Min(c => c.Level) : 0;

            Console.WriteLine($"  • Total Characters: {totalCharacters}");
            Console.WriteLine($"  • Average Level: {averageLevel:F2}");
            Console.WriteLine($"  • Highest Level: {maxLevel}");
            Console.WriteLine($"  • Lowest Level: {minLevel}");

            var totalWeapons = _context.Items.OfType<Weapon>().Count();
            var avgWeaponDamage = _context.Items.OfType<Weapon>().Any()
                ? _context.Items.OfType<Weapon>().Average(w => w.Damage)
                : 0;

            Console.WriteLine($"  • Total Weapons: {totalWeapons}");
            Console.WriteLine($"  • Average Weapon Damage: {avgWeaponDamage:F2}");

            // ================================================
            // Example 6: GroupBy with Aggregation
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 6: Characters Grouped by Level");
            Console.WriteLine(new string('=', 60));

            var charactersByLevel = _context.Characters
                .GroupBy(c => c.Level)
                .Select(g => new
                {
                    Level = g.Key,
                    Count = g.Count(),
                    Names = g.Select(c => c.Name).ToList()
                })
                .OrderBy(x => x.Level)
                .ToList();

            foreach (var group in charactersByLevel)
            {
                Console.WriteLine($"  Level {group.Level}: {group.Count} character(s)");
                foreach (var name in group.Names)
                {
                    Console.WriteLine($"    - {name}");
                }
            }

            // ================================================
            // Example 7: Room Statistics
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 7: Room Statistics with Character Data");
            Console.WriteLine(new string('=', 60));

            var roomStats = _context.Rooms
                .Select(r => new
                {
                    RoomName = r.Name,
                    CharacterCount = r.Characters.Count,
                    AverageLevel = r.Characters.Any() ? r.Characters.Average(c => c.Level) : 0,
                    Characters = r.Characters.Select(c => c.Name).ToList()
                })
                .ToList();

            foreach (var room in roomStats)
            {
                Console.WriteLine($"\n  Room: {room.RoomName}");
                Console.WriteLine($"    Characters: {room.CharacterCount}");
                Console.WriteLine($"    Avg Level: {room.AverageLevel:F2}");
                if (room.Characters.Any())
                {
                    Console.WriteLine($"    Occupants: {string.Join(", ", room.Characters)}");
                }
            }

            // ================================================
            // Example 8: Quantifiers - Any and All
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 8: Using Any() and All() Quantifiers");
            Console.WriteLine(new string('=', 60));

            var hasHighLevel = _context.Characters.Any(c => c.Level > 20);
            Console.WriteLine($"  • Any character above level 20? {hasHighLevel}");

            var allHaveItems = _context.Characters.All(c => c.Items.Count > 0);
            Console.WriteLine($"  • Do all characters have items? {allHaveItems}");

            var occupiedRooms = _context.Rooms
                .Where(r => r.Characters.Any())
                .Select(r => r.Name)
                .ToList();
            Console.WriteLine($"  • Occupied Rooms: {string.Join(", ", occupiedRooms)}");

            // ================================================
            // Example 9: Characters with Specific Equipment
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 9: Characters with Both Weapon and Armor Equipped");
            Console.WriteLine(new string('=', 60));

            var fullyEquipped = _context.Characters
                .Where(c => c.Equipment != null
                         && c.Equipment.Weapon != null
                         && c.Equipment.Armor != null)
                .Select(c => new
                {
                    c.Name,
                    WeaponName = c.Equipment.Weapon.Name,
                    WeaponDamage = c.Equipment.Weapon.Damage,
                    ArmorName = c.Equipment.Armor.Name,
                    ArmorDefense = c.Equipment.Armor.Defense
                })
                .ToList();

            if (fullyEquipped.Any())
            {
                foreach (var character in fullyEquipped)
                {
                    Console.WriteLine($"  • {character.Name}:");
                    Console.WriteLine($"      Weapon: {character.WeaponName} (Damage: {character.WeaponDamage})");
                    Console.WriteLine($"      Armor: {character.ArmorName} (Defense: {character.ArmorDefense})");
                }
            }
            else
            {
                Console.WriteLine("  No fully equipped characters found.");
            }

            // ================================================
            // Example 10: Top N Query
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 10: Top 3 Most Powerful Weapons");
            Console.WriteLine(new string('=', 60));

            var topWeapons = _context.Items
                .OfType<Weapon>()
                .OrderByDescending(w => w.Damage)
                .Take(3)
                .ToList();

            int rank = 1;
            foreach (var weapon in topWeapons)
            {
                Console.WriteLine($"  {rank}. {weapon.Name} - Damage: {weapon.Damage}");
                rank++;
            }

            // ================================================
            // Example 11: Nested Query - Above Average
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 11: Characters with Above-Average Level");
            Console.WriteLine(new string('=', 60));

            if (_context.Characters.Any())
            {
                var avgLvl = _context.Characters.Average(c => c.Level);
                var aboveAverage = _context.Characters
                    .Where(c => c.Level > avgLvl)
                    .OrderByDescending(c => c.Level)
                    .ToList();

                Console.WriteLine($"  Average Level: {avgLvl:F2}\n");
                foreach (var character in aboveAverage)
                {
                    Console.WriteLine($"  • {character.Name} - Level {character.Level}");
                }
            }

            // ================================================
            // Example 12: Complex Query - Multiple Conditions
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 12: Characters in Specific Room with Weapons");
            Console.WriteLine(new string('=', 60));

            var specificRoomName = "Dungeon"; // Change this to match your seed data
            var armedCharactersInRoom = _context.Characters
                .Where(c => c.Room != null
                         && c.Room.Name == specificRoomName
                         && c.Items.OfType<Weapon>().Any())
                .Select(c => new
                {
                    c.Name,
                    c.Level,
                    Weapons = c.Items.OfType<Weapon>().Select(w => new { w.Name, w.Damage }).ToList(),
                    TotalDamage = c.Items.OfType<Weapon>().Sum(w => w.Damage)
                })
                .OrderByDescending(x => x.TotalDamage)
                .ToList();

            if (armedCharactersInRoom.Any())
            {
                foreach (var character in armedCharactersInRoom)
                {
                    Console.WriteLine($"\n  • {character.Name} (Level {character.Level})");
                    Console.WriteLine($"    Total Weapon Damage: {character.TotalDamage}");
                    Console.WriteLine($"    Weapons:");
                    foreach (var weapon in character.Weapons)
                    {
                        Console.WriteLine($"      - {weapon.Name} (Damage: {weapon.Damage})");
                    }
                }
            }
            else
            {
                Console.WriteLine($"  No armed characters found in {specificRoomName}.");
            }

            // ================================================
            // Example 13: Monsters (if using TPH inheritance)
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 13: Monster Data (Goblins and Trolls)");
            Console.WriteLine(new string('=', 60));

            var goblins = _context.Monsters.OfType<Goblin>().ToList();
            var trolls = _context.Monsters.OfType<Troll>().ToList();

            if (goblins.Any())
            {
                Console.WriteLine("\n  Goblins:");
                foreach (var goblin in goblins.OrderByDescending(g => g.Gold))
                {
                    Console.WriteLine($"    • {goblin.Name} - HP: {goblin.HitPoints}, Gold: {goblin.Gold}, Attack: {goblin.Attack}");
                }

                var totalGold = goblins.Sum(g => g.Gold);
                Console.WriteLine($"\n  Total Goblin Gold: {totalGold}");
            }

            if (trolls.Any())
            {
                Console.WriteLine("\n  Trolls:");
                foreach (var troll in trolls.OrderByDescending(t => t.Defense))
                {
                    Console.WriteLine($"    • {troll.Name} - HP: {troll.HitPoints}, Defense: {troll.Defense}, Regenerate: {troll.Regenerate}");
                }
            }

            // ================================================
            // Example 14: Set Operations (Union example)
            // ================================================
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Example 14: Distinct Item Types Across All Characters");
            Console.WriteLine(new string('=', 60));

            var distinctItemNames = _context.Characters
                .SelectMany(c => c.Items)
                .Select(i => i.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            if (distinctItemNames.Any())
            {
                Console.WriteLine("  Unique Items in Game:");
                foreach (var itemName in distinctItemNames)
                {
                    Console.WriteLine($"    • {itemName}");
                }
            }

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("End of LINQ Demonstrations");
            Console.WriteLine(new string('=', 60) + "\n");
        }
    }
}
