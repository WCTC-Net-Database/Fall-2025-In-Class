using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using W9_EFCORE_INTRO.Models;

namespace W9_EFCORE_INTRO.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // "Server=bitsql.wctc.edu;Database=EFCore_10022_mmcarthey;User Id=mmcarthey;Password=YourPasswordHere;"
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFCore_10022_mmcarthey;Trusted_Connection=True;");
        }

        public void Seed()
        {
            if (!Rooms.Any())
            {
                var room1 = new Room
                {
                    Name = "Entrance Hall",
                    Description = "A grand hall with marble floors and a crystal chandelier."
                };
                var room2 = new Room
                {
                    Name = "Library",
                    Description = "Rows of ancient books line the walls, with a cozy reading nook in the corner."
                };
                Rooms.AddRange(room1, room2);
                SaveChanges();

                var character1 = new Character
                {
                    Name = "Aria the Brave",
                    Level = 5,
                    Room = room1
                };
                var character2 = new Character
                {
                    Name = "Luna the Wise",
                    Level = 7,
                    Room = room2
                };
                Characters.AddRange(character1, character2);
                SaveChanges();
            }
        }
    }
}
