using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int StatModifier { get; set; }
        public List<ClassSkill> ClassSkills { get; set; }

        public string ClassNames { get; set; }

    }
}
