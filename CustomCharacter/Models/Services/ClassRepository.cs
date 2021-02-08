using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Services
{
    public class ClassRepository : IClass
    {
        public Task AddAbilityToClass(int classId, int abilityId)
        {
            throw new NotImplementedException();
        }

        public Task<ClassDTO> CreateClass(ClassDTO classDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClass(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ClassDTO> GetClass(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClassDTO>> GetClasses()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAbilityFromClass(int classId, int abilityId)
        {
            throw new NotImplementedException();
        }

        public Task<Class> UpdateClass(ClassDTO classDTO)
        {
            throw new NotImplementedException();
        }
    }
}
