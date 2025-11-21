using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W13_ROOM_NAV.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        // nullable because not all rooms have neighbors in all directions
        public Room? North { get; set; }
        public Room? South { get; set; }
        public Room? East { get; set; }
        public Room? West { get; set; }

        public Room(string name, string desc)
        {
            Name = name;
            Desc = desc;
        }
    }
}
