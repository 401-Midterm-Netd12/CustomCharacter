using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Services
{
    public class CharacterRepository : ICharacter
    {
        public Task<Character> Create(CharacterDTO CharacterDTO)
        {
            Character character = new Character() 
            {
                Id =CharacterDTO.Id,
                ClassId = CharacterDTO.ClassId,
                RaceId = CharacterDTO.RaceId,
                Name = CharacterDTO.Name,
                UserId = CharacterDTO.UserId, //feel like I should be just able to grab the current users ID
                HP = CharacterDTO.HP,
                Dex = CharacterDTO.Dex,
                Strength = CharacterDTO.Strength
            };

        }

        public Task DeleteCharacter(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CharacterDTO> GetCharacter(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CharacterDTO>> GetCharacters()
        {
            throw new NotImplementedException();
        }

        public Task<Character> UpdateCharacter(int Id, CharacterDTO Character)
        {
            throw new NotImplementedException();
        }
    }
}
