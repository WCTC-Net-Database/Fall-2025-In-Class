using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2_EnhancedFileIO
{
    // Model, Resource, Entity, Class, Container
    public class Character
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public List<string> Equipment { get; set; }

        public Character()
        {
            Equipment = new List<string>();
            // must be explicitly defined if a parameterized constructor is present
        }
        // parameterized constructor
        public Character(string name, string profession, int level, int hitPoints, List<string> equipment)
        {
            Name = name;
            Profession = profession;
            Level = level;
            HitPoints = hitPoints;
            Equipment = equipment;
        }
    }
}
