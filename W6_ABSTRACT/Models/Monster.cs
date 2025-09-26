using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6_ABSTRACT.Models
{
    // shared properties and methods
    public abstract class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Monster Attackee { get; set; }

        protected Monster(Monster attackee)
        {
            Attackee = attackee;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} attacks {Attackee.Name} for 4 damage!");
            Attackee.Health -= 4;
        }

        public abstract void Defend();
    }
}
