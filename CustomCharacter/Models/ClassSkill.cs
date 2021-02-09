using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models
{
    public class ClassSkill
    {
        public int ClassId { get; set; }
        public int SkillId { get; set; }

        public Class ClassNav { get; set; }
        public Skill SkillNav { get; set; }
    }
}
