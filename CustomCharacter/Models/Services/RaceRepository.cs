using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Services
{
    public class RaceRepository : IRace
    {
        public Task AddSkillToClass(int classId, int skillId)
        {
            throw new NotImplementedException();
        }

        public Task<RaceDTO> CreateRace(RaceDTO raceDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClass(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ClassDTO> GetRace(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClassDTO>> GetRaces()
        {
            throw new NotImplementedException();
        }

        public Task RemoveSkillFromClass(int classId, int skillId)
        {
            throw new NotImplementedException();
        }

        public Task<Class> UpdateRace(RaceDTO raceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
