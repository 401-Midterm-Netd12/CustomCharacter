using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface IRace
    {
        Task<Race> CreateRace(RaceDTO raceDTO);
        Task<Race> GetRace(int Id);
        Task<List<RaceDTO>> GetRaces();
        Task<Race> UpdateRace(RaceDTO raceDTO);
        Task DeleteRace(int Id);
        Task AddAbilityToRace(int raceId, int abilityId);

        Task RemoveAbilityFromRace(int raceId, int abilityId);
    }
}
