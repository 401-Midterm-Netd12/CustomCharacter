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
        public string RaceType { get; set; }
        public List<RaceAbility> Abilities { get; set; }

    }
}
