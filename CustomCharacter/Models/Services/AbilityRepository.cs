using CustomCharacter.Data;
using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomCharacter.Models.Services
{
    public class AbilityRepository : IAbility
    {
        private readonly CustomCharacterContext _context;

        public AbilityRepository(CustomCharacterContext context)
        {
            _context = context;
        }
       

        public async Task<Ability> Create(AbilityDTO AbilityDTO)
        {
            Ability ability = new Ability()
            {
                Id = AbilityDTO.Id,
                Name = AbilityDTO.Name,
                Desc = AbilityDTO.Desc
            };

            _context.Entry(ability).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return ability;
        }  

        public async Task<List<AbilityDTO>> GetAbilities()
        {
            var abilities = await _context.Abilities.ToListAsync();
            var abilityList = new List<AbilityDTO>();

            foreach (var ability in abilities)
                abilityList.Add(await GetAbility(ability.Id));
            
            return abilityList;
        }

        public async Task<AbilityDTO> GetAbility(int Id)
        {
            Ability ability = await _context.Abilities.FindAsync(Id);

            AbilityDTO abilityDTO = new AbilityDTO()
            {
                Id = ability.Id,
                Name = ability.Name,
                Desc = ability.Desc
            };

            return abilityDTO;
        }


        public async Task<Ability> UpdateAbilities(int Id, AbilityDTO AbilityDTO)
        {
            Ability ability = new Ability()
            {
                Id = AbilityDTO.Id,
                Name = AbilityDTO.Name,
                Desc = AbilityDTO.Desc
            };
            _context.Entry(ability).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ability;
        }

        public async Task DeleteAbility(int Id)
        {
            Ability ability = await _context.Abilities.FindAsync(Id);
            _context.Entry(ability).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
