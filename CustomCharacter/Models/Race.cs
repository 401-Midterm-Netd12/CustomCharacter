using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCharacter.Models.API;

namespace CustomCharacter.Models
{
    public class Race
    {
        public int Id { get; set; }

        public int StatModifier { get; set; }
        public RaceTypes RaceType { get; set; }
        public List<AbilityDTO> Abilities { get; set; }
        public enum RaceTypes { Elf = 1, Goblin = 2, Human = 3, Dwarf = 4, Gnome = 5 }
    }
}
