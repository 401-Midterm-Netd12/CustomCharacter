using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class Race
    {
        public int Id { get; set; }
        public int RaceAbility { get; set; }

        public int StatModifier { get; set; }

        public enum RaceType { Elf = 1, Goblin = 2, Human = 3, Dwarf = 4, Gnome = 5 }


    
    }
}
