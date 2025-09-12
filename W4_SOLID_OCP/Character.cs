using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4_SOLID_OCP
{
    // Model, Resource, Entity, Class, Container
    public class Character
    {
        public string Name { get; set; }
        
        [JsonProperty("class")]
        public string Profession { get; set; }
        public int Level { get; set; }

        [JsonProperty("hp")]
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

        override public string ToString()
        {
            string equipmentList = Equipment != null && Equipment.Count > 0 ? string.Join(", ", Equipment) : "None";
            return $"Name: {Name}\nProfession: {Profession}\nLevel: {Level}\nHit Points: {HitPoints}\nEquipment: {equipmentList}";
        }

        public void DisplayCharacter(Character character)
        {
            Console.WriteLine($"{character.Name}");
            Console.WriteLine();
        }
    }
}
