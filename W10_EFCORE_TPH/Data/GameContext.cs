using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using W10_EFCORE_TPH.Models;
using W9_EFCORE_INTRO.Models;

namespace W9_EFCORE_INTRO.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Room> Rooms { get; set; }

        // TPH - Single Table for all Enemy types
        public DbSet<Monster> Monsters { get; set; }

        // Create two separate Tables for Trolls and Goblins
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

            // FLUENT API EXAMPLES
            //modelBuilder.HasSequence<int>("MonsterSeq", schema: "shared")
            //    .StartsAt(1)
            //    .IncrementsBy(1);   
            //modelBuilder.HasSequence<int>("TrollSeq", schema: "shared")
            //    .StartsAt(1)
            //    .IncrementsBy(1);
            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.Characters)
            //    .WithOne(c => c.Room)
            //    .HasForeignKey(c => c.RoomId)
            //    .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

    }
}
