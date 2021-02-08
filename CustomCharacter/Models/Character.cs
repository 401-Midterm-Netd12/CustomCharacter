using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Dex { get; set; }
        public int Strength { get; set; }
    }
}
