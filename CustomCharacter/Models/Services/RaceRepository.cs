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

        RaceRepository(CustomCharacterContext context)
        {
            _context = context;

        }

        public async Task<RaceDTO> CreateRace(RaceDTO raceDTO)
        {
            Race newRace = new Race()
            {
                Id = raceDTO.Id,
                RaceType = raceDTO.RaceType,
                StatModifier = raceDTO.StatModifer,
                Abilities = raceDTO.Abilities
            };

            _context.Entry(newRace).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return raceDTO;
        }

        public Task<ClassDTO> GetRace(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClassDTO>> GetRaces()
        {
            throw new NotImplementedException();
        }

        public Task AddAbilityToRace(int classId, int skillId)
        {
            throw new NotImplementedException();
        }
        public Task RemoveAbilityFromRace(int classId, int skillId)
        {
            throw new NotImplementedException();
        }

        public Task<Class> UpdateRace(RaceDTO raceDTO)
        {
            throw new NotImplementedException();
        }
        public Task DeleteClass(int Id)
        {
            throw new NotImplementedException();
        }
    }
