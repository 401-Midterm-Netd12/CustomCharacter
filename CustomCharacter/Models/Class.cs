using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class Class
    {
        public int Id { get; set; }
        public List<ClassSkill> ClassSkills { get; set; }
        public int StatModifier { get; set; }
        public ClassNames ClassName { get; set; }
        public enum ClassNames { Barbarian = 1, Mage = 2, Ranger = 3, Rogue = 4, Knight = 5, Monk = 6, Bard = 7 }
    }
}
