using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.API
{
    public class RaceDTO
    {
        public int Id { get; set; }
        public string RaceType { get; set; }
        public List<Ability> Abilities { get; set; }
    }
}
