using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CustomCharacter.Models.Race;

namespace CustomCharacter.Models.API
{
    public class RaceDTO
    {
        public int Id { get; set; }
        public RaceTypes RaceType { get; set; }

        public int StatModifer { get; set; }
        public List<AbilityDTO> Abilities { get; set; }
    }
}
