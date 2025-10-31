using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W10_EFCORE_TPH.Models
{
    public abstract class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
    }

    public class Goblin : Monster
    {
        public int Gold { get; set; }
        public int Attack { get; set; }
    }

    public class Troll : Monster
    {
        public int Defense { get; set; }
        public bool Regenerate { get; set; }
    }
}
