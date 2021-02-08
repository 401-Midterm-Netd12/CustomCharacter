using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface IAbility
    {
        Task<Ability> Create(AbilityDTO Ability);
        Task<AbilityDTO> GetAbility(int Id);
        Task<List<AbilityDTO>> GetAbilities();
        Task<Ability> UpdateAbilities(int Id, AbilityDTO Ability);
        Task DeleteAbility(int Id);
    }
}
