using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CustomCharacter.Models.Class;

namespace CustomCharacter.Models.API
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public int statModifier { get; set; }
        public ClassNames ClassName { get; set; }
        public List<ClassSkill> Skills { get; set; }
    }
}
