# W12 - Advanced LINQ Instructor Notes

## Overview
This session covers advanced LINQ (Language Integrated Query) operations in preparation for the final exam. Students should be familiar with basic LINQ concepts from previous weeks.

## Domain Model Recap
- **Character**: Id, Name, Level, Equipment, Items (List<Item>), Room
- **Room**: Id, Name, Description, Characters (ICollection<Character>)
- **Monster** (abstract): Id, Name, HitPoints
  - **Goblin**: Gold, Attack
  - **Troll**: Defense, Regenerate
- **Item** (abstract): Id, Name, Description, Characters (List<Character>)
  - **Weapon**: Damage
  - **Armor**: Defense
- **Equipment**: Id, Weapon, Armor

---

## 1. Basic LINQ Operations

### 1.1 Filtering with Where
```csharp
// Find all characters above level 5
var highLevelCharacters = context.Characters
    .Where(c => c.Level > 5)
    .ToList();

// Find all goblins with more than 100 gold
var richGoblins = context.Monsters
    .OfType<Goblin>()
    .Where(g => g.Gold > 100)
    .ToList();

// Find characters in a specific room
var dungeonCharacters = context.Characters
    .Where(c => c.Room != null && c.Room.Name == "Dungeon")
    .ToList();
```

### 1.2 Projection with Select
```csharp
// Get just character names
var characterNames = context.Characters
    .Select(c => c.Name)
    .ToList();

// Create a simplified view with anonymous type
var characterSummary = context.Characters
    .Select(c => new
    {
        c.Name,
        c.Level,
        RoomName = c.Room != null ? c.Room.Name : "No Room",
        ItemCount = c.Items.Count
    })
    .ToList();

// Project weapons with their damage values
var weaponStats = context.Items
    .OfType<Weapon>()
    .Select(w => new { w.Name, w.Damage, w.Description })
    .ToList();
```

### 1.3 Sorting with OrderBy / OrderByDescending
```csharp
// Characters ordered by level (ascending)
var orderedByLevel = context.Characters
    .OrderBy(c => c.Level)
    .ToList();

// Characters ordered by level descending, then by name
var orderedComplex = context.Characters
    .OrderByDescending(c => c.Level)
    .ThenBy(c => c.Name)
    .ToList();

// Goblins ordered by gold descending
var wealthiestGoblins = context.Monsters
    .OfType<Goblin>()
    .OrderByDescending(g => g.Gold)
    .ToList();
```

---

## 2. Working with Related Data

### 2.1 SelectMany - Flattening Collections
```csharp
// Get all items from all characters (flattened)
var allItems = context.Characters
    .SelectMany(c => c.Items)
    .ToList();

// Get all characters from all rooms
var allCharactersFromRooms = context.Rooms
    .SelectMany(r => r.Characters)
    .ToList();

// Get all items with their owner's name
var itemsWithOwners = context.Characters
    .SelectMany(c => c.Items, (character, item) => new
    {
        CharacterName = character.Name,
        ItemName = item.Name,
        ItemType = item.GetType().Name
    })
    .ToList();
```

### 2.2 Complex Navigations
```csharp
// Find all weapons owned by characters in a specific room
var weaponsInDungeon = context.Rooms
    .Where(r => r.Name == "Dungeon")
    .SelectMany(r => r.Characters)
    .SelectMany(c => c.Items)
    .OfType<Weapon>()
    .ToList();

// Characters with their equipped weapon damage (if any)
var characterWeaponPower = context.Characters
    .Select(c => new
    {
        c.Name,
        WeaponDamage = c.Equipment != null && c.Equipment.Weapon != null
            ? c.Equipment.Weapon.Damage
            : 0
    })
    .ToList();
```

---

## 3. Aggregation Operations

### 3.1 Count, Sum, Average, Min, Max
```csharp
// Count total characters
var totalCharacters = context.Characters.Count();

// Count characters above level 10
var highLevelCount = context.Characters.Count(c => c.Level > 10);

// Average character level
var averageLevel = context.Characters.Average(c => c.Level);

// Highest level character
var maxLevel = context.Characters.Max(c => c.Level);

// Total gold across all goblins
var totalGold = context.Monsters
    .OfType<Goblin>()
    .Sum(g => g.Gold);

// Average weapon damage
var avgWeaponDamage = context.Items
    .OfType<Weapon>()
    .Average(w => w.Damage);
```

### 3.2 Aggregation with Grouping
```csharp
// Count characters per room
var charactersPerRoom = context.Rooms
    .Select(r => new
    {
        RoomName = r.Name,
        CharacterCount = r.Characters.Count
    })
    .ToList();

// Average items per character
var avgItemsPerCharacter = context.Characters
    .Average(c => c.Items.Count);
```

---

## 4. Grouping Operations

### 4.1 GroupBy Basics
```csharp
// Group characters by level
var charactersByLevel = context.Characters
    .GroupBy(c => c.Level)
    .Select(g => new
    {
        Level = g.Key,
        Characters = g.ToList(),
        Count = g.Count()
    })
    .ToList();

// Group items by type (Weapon vs Armor)
var itemsByType = context.Items
    .GroupBy(i => i.GetType().Name)
    .Select(g => new
    {
        ItemType = g.Key,
        Count = g.Count(),
        Items = g.ToList()
    })
    .ToList();
```

### 4.2 Advanced Grouping
```csharp
// Group characters by room and calculate average level per room
var roomStats = context.Rooms
    .Select(r => new
    {
        RoomName = r.Name,
        CharacterCount = r.Characters.Count,
        AverageLevel = r.Characters.Any() ? r.Characters.Average(c => c.Level) : 0,
        TotalLevels = r.Characters.Sum(c => c.Level)
    })
    .ToList();

// Group goblins by gold ranges
var goblinsByWealth = context.Monsters
    .OfType<Goblin>()
    .AsEnumerable() // Switch to client-side evaluation for complex grouping
    .GroupBy(g => g.Gold switch
    {
        < 50 => "Poor",
        < 100 => "Middle Class",
        _ => "Wealthy"
    })
    .Select(g => new
    {
        WealthCategory = g.Key,
        Count = g.Count(),
        TotalGold = g.Sum(x => x.Gold)
    })
    .ToList();
```

---

## 5. Quantifiers

### 5.1 Any and All
```csharp
// Check if any character has level > 20
var hasHighLevel = context.Characters.Any(c => c.Level > 20);

// Check if all characters have at least one item
var allHaveItems = context.Characters.All(c => c.Items.Count > 0);

// Rooms that have any characters
var occupiedRooms = context.Rooms
    .Where(r => r.Characters.Any())
    .ToList();

// Characters that have any weapons
var charactersWithWeapons = context.Characters
    .Where(c => c.Items.Any(i => i is Weapon))
    .ToList();

// Check if all goblins have gold > 0
var allGoblinsHaveGold = context.Monsters
    .OfType<Goblin>()
    .All(g => g.Gold > 0);
```

### 5.2 Contains
```csharp
// Find characters whose name is in a specific list
var nameList = new[] { "Aragorn", "Gandalf", "Frodo" };
var specificCharacters = context.Characters
    .Where(c => nameList.Contains(c.Name))
    .ToList();
```

---

## 6. Set Operations

### 6.1 Distinct
```csharp
// Get distinct character levels
var distinctLevels = context.Characters
    .Select(c => c.Level)
    .Distinct()
    .ToList();

// Get distinct room names where characters reside
var distinctRoomNames = context.Characters
    .Where(c => c.Room != null)
    .Select(c => c.Room.Name)
    .Distinct()
    .ToList();
```

### 6.2 Union, Intersect, Except
```csharp
// Union: Items owned by character A OR character B
var characterA = context.Characters.First(c => c.Name == "Aragorn");
var characterB = context.Characters.First(c => c.Name == "Gandalf");

var combinedItems = characterA.Items
    .Union(characterB.Items)
    .ToList();

// Intersect: Items owned by BOTH characters
var sharedItems = characterA.Items
    .Intersect(characterB.Items)
    .ToList();

// Except: Items owned by A but NOT by B
var uniqueToA = characterA.Items
    .Except(characterB.Items)
    .ToList();
```

---

## 7. Partitioning

### 7.1 Take and Skip
```csharp
// Get top 5 highest level characters
var topFive = context.Characters
    .OrderByDescending(c => c.Level)
    .Take(5)
    .ToList();

// Skip first 10 characters, take next 5 (pagination)
var pageTwo = context.Characters
    .OrderBy(c => c.Name)
    .Skip(10)
    .Take(5)
    .ToList();

// Get the most powerful weapon
var mostPowerfulWeapon = context.Items
    .OfType<Weapon>()
    .OrderByDescending(w => w.Damage)
    .FirstOrDefault();
```

### 7.2 TakeWhile and SkipWhile
```csharp
// Take characters while level is less than 10
var lowLevelCharacters = context.Characters
    .OrderBy(c => c.Level)
    .AsEnumerable() // Client-side evaluation
    .TakeWhile(c => c.Level < 10)
    .ToList();

// Skip characters while level is less than 10, then take the rest
var midToHighLevel = context.Characters
    .OrderBy(c => c.Level)
    .AsEnumerable() // Client-side evaluation
    .SkipWhile(c => c.Level < 10)
    .ToList();
```

---

## 8. Element Operations

### 8.1 First, FirstOrDefault, Single, SingleOrDefault
```csharp
// First character (throws if none exist)
var firstCharacter = context.Characters.First();

// First character named "Aragorn" or default if not found
var aragorn = context.Characters.FirstOrDefault(c => c.Name == "Aragorn");

// Single character with a specific ID (throws if more than one)
var character = context.Characters.Single(c => c.Id == 1);

// Single or default (returns null if not found, throws if multiple)
var uniqueCharacter = context.Characters.SingleOrDefault(c => c.Name == "Unique");
```

---

## 9. Join Operations

### 9.1 Inner Join
```csharp
// Join characters with rooms (only characters that have rooms)
var characterRoomJoin = context.Characters
    .Where(c => c.Room != null)
    .Select(c => new
    {
        CharacterName = c.Name,
        RoomName = c.Room.Name,
        c.Level
    })
    .ToList();

// Alternative: Explicit Join syntax
var explicitJoin = context.Characters
    .Join(
        context.Rooms,
        character => character.Room.Id,
        room => room.Id,
        (character, room) => new
        {
            CharacterName = character.Name,
            RoomName = room.Name,
            RoomDescription = room.Description
        })
    .ToList();
```

### 9.2 Left Join (Group Join)
```csharp
// Left join: All rooms with their characters (even if no characters)
var roomsWithCharacters = context.Rooms
    .Select(r => new
    {
        RoomName = r.Name,
        Characters = r.Characters.Select(c => c.Name).ToList(),
        CharacterCount = r.Characters.Count
    })
    .ToList();
```

---

## 10. Advanced Scenarios

### 10.1 Nested Queries
```csharp
// Find characters with above-average level
var avgLevel = context.Characters.Average(c => c.Level);
var aboveAverageCharacters = context.Characters
    .Where(c => c.Level > avgLevel)
    .ToList();

// Find rooms containing characters with the highest level
var maxLevel = context.Characters.Max(c => c.Level);
var roomsWithMaxLevelCharacters = context.Rooms
    .Where(r => r.Characters.Any(c => c.Level == maxLevel))
    .ToList();
```

### 10.2 Complex Filtering
```csharp
// Characters who have both a weapon AND armor equipped
var fullyEquipped = context.Characters
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

// Find characters with specific item types in inventory
var charactersWithSwords = context.Characters
    .Where(c => c.Items.OfType<Weapon>().Any(w => w.Name.Contains("Sword")))
    .ToList();
```

### 10.3 Combining Multiple Conditions
```csharp
// Complex query: High-level characters in dungeon with weapons
var dungeonWarriors = context.Characters
    .Where(c => c.Level >= 10
             && c.Room != null
             && c.Room.Name == "Dungeon"
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
```

---

## 11. Method Syntax vs Query Syntax

### 11.1 Method Syntax (Preferred in most cases)
```csharp
var results = context.Characters
    .Where(c => c.Level > 5)
    .OrderBy(c => c.Name)
    .Select(c => new { c.Name, c.Level })
    .ToList();
```

### 11.2 Query Syntax
```csharp
var results = (from c in context.Characters
               where c.Level > 5
               orderby c.Name
               select new { c.Name, c.Level })
              .ToList();
```

### 11.3 Complex Query Syntax with Joins
```csharp
var results = (from c in context.Characters
               where c.Room != null
               join r in context.Rooms on c.Room.Id equals r.Id
               orderby c.Level descending
               select new
               {
                   CharacterName = c.Name,
                   RoomName = r.Name,
                   c.Level
               })
              .ToList();
```

---

## 12. Performance Considerations

### 12.1 Deferred Execution vs Immediate Execution
```csharp
// Deferred: Query is not executed until enumerated
var query = context.Characters.Where(c => c.Level > 5); // Not executed yet

// Immediate: Executed immediately with ToList(), ToArray(), Count(), etc.
var list = context.Characters.Where(c => c.Level > 5).ToList(); // Executed now

// Deferred execution allows query composition
query = query.OrderBy(c => c.Name); // Still not executed
var results = query.ToList(); // NOW executed with both Where and OrderBy
```

### 12.2 AsEnumerable() - Client vs Server Evaluation
```csharp
// Server-side: Executes in database (preferred when possible)
var serverSide = context.Characters
    .Where(c => c.Level > 5)
    .ToList();

// Client-side: Brings all data to memory first (use sparingly)
var clientSide = context.Characters
    .AsEnumerable() // Everything after this runs in memory
    .Where(c => SomeComplexCSharpMethod(c))
    .ToList();
```

### 12.3 Avoiding N+1 Queries
```csharp
// BAD: N+1 problem - causes multiple database queries
var characters = context.Characters.ToList();
foreach (var c in characters)
{
    // Each iteration triggers a new query for Items
    Console.WriteLine($"{c.Name} has {c.Items.Count} items");
}

// GOOD: Use Include to eagerly load related data
var charactersWithItems = context.Characters
    .Include(c => c.Items)
    .ToList();
foreach (var c in charactersWithItems)
{
    Console.WriteLine($"{c.Name} has {c.Items.Count} items");
}
```

---

## 13. Common Patterns for Exam

### Pattern 1: Find entities with specific related data
```csharp
// Find characters who own a specific item
var itemName = "Excalibur";
var owners = context.Characters
    .Where(c => c.Items.Any(i => i.Name == itemName))
    .ToList();
```

### Pattern 2: Aggregate over filtered data
```csharp
// Total damage of all weapons owned by high-level characters
var totalDamage = context.Characters
    .Where(c => c.Level >= 10)
    .SelectMany(c => c.Items)
    .OfType<Weapon>()
    .Sum(w => w.Damage);
```

### Pattern 3: Group and aggregate
```csharp
// Average level of characters per room
var roomAvgLevel = context.Rooms
    .Where(r => r.Characters.Any())
    .Select(r => new
    {
        RoomName = r.Name,
        AvgLevel = r.Characters.Average(c => c.Level),
        MinLevel = r.Characters.Min(c => c.Level),
        MaxLevel = r.Characters.Max(c => c.Level)
    })
    .ToList();
```

### Pattern 4: Top N with ordering
```csharp
// Top 3 goblins by gold
var richestGoblins = context.Monsters
    .OfType<Goblin>()
    .OrderByDescending(g => g.Gold)
    .Take(3)
    .ToList();
```

### Pattern 5: Existence checks with Any/All
```csharp
// Rooms where all characters are high level (>= 15)
var eliteRooms = context.Rooms
    .Where(r => r.Characters.Any() && r.Characters.All(c => c.Level >= 15))
    .ToList();
```

---

## 14. Common Pitfalls

1. **Forgetting ToList()/ToArray()**: Query doesn't execute until enumerated
2. **N+1 Queries**: Not using Include/ThenInclude for related data
3. **Client Evaluation**: Using non-translatable methods forces client-side execution
4. **Null Reference**: Not checking for null navigation properties
5. **Multiple Enumeration**: Enumerating IQueryable multiple times executes query each time

---

## Key Takeaways for Final Exam

1. **Master Where, Select, SelectMany** - Most common operations
2. **Understand GroupBy and Aggregations** - Count, Sum, Average, etc.
3. **Know when to use Any, All, Contains**
4. **Practice OrderBy with ThenBy** for complex sorting
5. **Understand OfType<T>()** for filtering by derived types
6. **Know the difference** between First/Single and their OrDefault variants
7. **Practice nested queries** and complex filtering
8. **Understand projection** with anonymous types
9. **Master navigation properties** and SelectMany for related data
10. **Remember Include** for eager loading to avoid N+1 problems

---

## Additional Resources

- Microsoft LINQ Documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
- Entity Framework Core Query Documentation: https://docs.microsoft.com/en-us/ef/core/querying/

---

**Good luck with the final exam!**
