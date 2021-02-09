using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<RaceAbility> AbilityList { get; set; }
    }
}
