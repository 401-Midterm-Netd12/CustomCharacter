using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.API
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public List<SkillDTO> Skills { get; set; }
    }
}
