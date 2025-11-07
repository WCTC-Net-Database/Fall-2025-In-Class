using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W9_EFCORE_INTRO.Models;

namespace W10_EFCORE_TPH.Models
{
    public class CharacterAbility // bridge table
    {
        public int Id { get; set; }
        public List<Character> Characters { get; set; }
        public List<Ability> Abilities { get; set; }
    }
}
