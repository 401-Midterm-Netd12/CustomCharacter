using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface ISkill
    {
        Task<Skill> Create(SkillDTO Skill);
        Task<SkillDTO> GetSkill(int Id);
        Task<List<SkillDTO>> GetSkills();
        Task<Skill> UpdateSkill(int Id, SkillDTO Skill);
        Task DeleteSkill(int Id);

    }
}
