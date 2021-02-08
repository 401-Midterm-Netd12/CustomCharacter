using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface IRace
    {
        Task<RaceDTO> CreateRace(RaceDTO raceDTO);
        Task<ClassDTO> GetRace(int Id);
        Task<List<ClassDTO>> GetRaces();
        Task<Class> UpdateRace(RaceDTO raceDTO);
        Task DeleteClass(int Id);
        Task AddAbilityToRace(int raceId, int abilityId);

        Task RemoveAbilityFromRace(int raceId, int abilityId);
    }
}
