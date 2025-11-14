using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W12_ADV_LINQ.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // navigation property
        public virtual List<Character> Characters { get; set; }

        override public string ToString()
        {
            return $"{Name} (Id: {Id}): {Description}";
        }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }

    }

    public class Armor : Item
    {
        public int Defense { get; set; }
    }
}
