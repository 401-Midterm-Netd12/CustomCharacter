using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RaceId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Dex { get; set; }
        public int Strength { get; set; }

        public AppUser CharAppUser { get; set; }
        public Race CharRace { get; set; }
        public Class CharClass { get; set; }
    }
}
