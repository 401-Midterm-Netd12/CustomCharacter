using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface IClass
    {
        Task<Class> CreateClass(ClassDTO classDTO);
        Task<ClassDTO> GetClass(int Id);
        Task<List<ClassDTO>> GetClasses();
        Task<Class> UpdateClass(Class Class);
        Task DeleteClass(int Id);
        Task AddAbilityToClass(int classId, int abilityId);

        Task RemoveAbilityFromClass(int classId, int abilityId);
    }
}
