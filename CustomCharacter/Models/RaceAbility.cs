using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class RaceAbility
    {
        public int RaceId { get; set; }
        public int AbilityId { get; set; }

        public Race RaceInRace { get; set; }
        public Ability AbilityInRace { get; set; }
    }
}
