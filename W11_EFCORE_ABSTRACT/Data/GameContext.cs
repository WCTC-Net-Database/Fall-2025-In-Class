using Microsoft.EntityFrameworkCore;
using W11_EFCORE_ABSTRACT.Models;

namespace W11_EFCORE_ABSTRACT.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        // TPH - Single Table for all Item types
        // If you use TPH for Items, comment out the two DbSet lines below for Weapons and Armors
        // Using TPH means adding the model configurations in OnModelCreating method
        public DbSet<Item> Items { get; set; }

        // TPT - Create two separate Tables for Weapons and Armors
        //public DbSet<Weapon> Weapons { get; set; }
        //public DbSet<Armor> Armors { get; set; }

        // TPH - Single Table for all Enemy types
        public DbSet<Monster> Monsters { get; set; }

        // TPT - Create two separate Tables for Trolls and Goblins
        //public DbSet<Troll> Trolls { get; set; }
        //public DbSet<Goblin> Goblins { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // "Server=bitsql.wctc.edu;Database=EFCore_10022_mmcarthey;User Id=mmcarthey;Password=YourPasswordHere;"
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GameDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH Inheritance
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>("MonsterType")
                .HasValue<Goblin>("Goblin")
                .HasValue<Troll>("Troll");

            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>("ItemType")
                .HasValue<Weapon>("Weapon")
                .HasValue<Armor>("Armor");

            base.OnModelCreating(modelBuilder);
        }

    }
}
