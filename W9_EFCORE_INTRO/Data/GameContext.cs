using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using W9_EFCORE_INTRO.Models;

namespace W9_EFCORE_INTRO.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
