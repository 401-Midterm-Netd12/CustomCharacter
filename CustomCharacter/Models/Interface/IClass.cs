using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface IClass
    {
        Task<ClassDTO> CreateClass(ClassDTO classDTO);
        Task<ClassDTO> GetClass(int Id);
        Task<List<ClassDTO>> GetClasses();
        Task<Class> UpdateClass(ClassDTO classDTO);
        Task DeleteClass(int Id);

        //new methods required in the service to add and remove amenities
        Task AddAbilityToClass (int classId, int abilityId);

        Task RemoveAbilityFromClass (int classId, int abilityId);
    }
}
