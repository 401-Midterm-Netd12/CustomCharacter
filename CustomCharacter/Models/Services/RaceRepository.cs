using CustomCharacter.Data;
using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Services
{
    public class RaceRepository : IRace
    {
        private readonly CustomCharacterContext _context;

        public RaceRepository(CustomCharacterContext context)
        {
            _context = context;

        }

        public async Task<Race> CreateRace(RaceDTO raceDTO)
        {
            Race newRace = new Race()
            {
                Id = raceDTO.Id,
                RaceType = raceDTO.RaceType,
                StatModifier = raceDTO.StatModifer
            };

            _context.Entry(newRace).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRace;
        }

        public async Task<Race> GetRace(int Id)
        {
            var race = await _context.Races.Where(Race => Race.Id == Id).FirstOrDefaultAsync();

            RaceDTO raceDTO = new RaceDTO()
            {
                Id = Id,
                RaceType = race.RaceType,
                StatModifer = race.StatModifier,
                DTOAbilities = race.Abilities.ToList()

            };
            return race;
        }

        public async Task<List<RaceDTO>> GetRaces()
        {
            var race = await _context.Races.Include(Race => Race.Abilities).ToListAsync();
            return race
            .Select(Race => new RaceDTO
            {
                Id = Race.Id,
                RaceType = Race.RaceType,
                StatModifer = Race.StatModifier,
                DTOAbilities = Race.Abilities.ToList()

            }).ToList();
        }

        public async Task AddAbilityToRace(int raceId, int abilityId)
        {

            RaceAbility raceAbility = new RaceAbility()
            {
                RaceId = raceId,
                AbilityId = abilityId
            };

            _context.Entry(raceAbility).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAbilityFromRace(int raceId, int abilityId)
        {
            var result = await _context.RaceAbilities.FirstOrDefaultAsync(x => x.RaceId == raceId && x.AbilityId == abilityId);

            _context.Entry(result).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Race> UpdateRace(RaceDTO raceDTO)
        {
            var race = await GetRace(raceDTO.Id);
            race.Id = raceDTO.Id;
            race.RaceType = raceDTO.RaceType;
            race.StatModifier = raceDTO.StatModifer;
            race.Abilities = raceDTO.DTOAbilities.ToList();

            _context.Entry(race).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return race;

        }
        public async Task DeleteRace(int Id)
        {
            Race race = await GetRace(Id);
            _context.Entry(race).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
