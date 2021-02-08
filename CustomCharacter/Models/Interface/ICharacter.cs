using CustomCharacter.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Interface
{
    public interface ICharacter
    {
        Task<Character> Create(CharacterDTO CharacterDTO);
        Task<CharacterDTO> GetCharacter(int Id);
        Task<List<CharacterDTO>> GetCharacters();
        Task<Character> UpdateCharacter(int Id, CharacterDTO CharacterDTO);
        Task DeleteCharacter(int Id);
    
    }
}
