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
    public class CharacterRepository : ICharacter
    {
        private readonly CustomCharacterContext _context;
        public CharacterRepository(CustomCharacterContext context)
        {
            _context = context;
        }
        public async Task<Character> Create(CharacterDTO CharacterDTO)
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

            _context.Entry(character).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<CharacterDTO> GetCharacter(int Id)
        {
            Character character = await _context.Characters.FindAsync(Id);

            CharacterDTO characterDTO = new CharacterDTO()
            {
                Id = Id,
                Name = character.Name,
                UserId = character.UserId,
                RaceId = character.RaceId,
                ClassId = character.ClassId,
                Strength = character.Strength,
                HP = character.HP,
                Dex = character.Dex
            };

            //TODO: Get abilities and skills form race and class
            return characterDTO;
        }

        public async Task<List<CharacterDTO>> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();
            var charaterList = new List<CharacterDTO>();

            foreach(var items in characters)
            {
                charaterList.Add(await GetCharacter(items.Id));
            }
            return charaterList;
        }

        public async Task<Character> UpdateCharacter(int Id, CharacterDTO CharacterDTO)
        {
            Character character = new Character()
            {
                Id = Id,
                Name = CharacterDTO.Name,
                UserId = CharacterDTO.UserId,
                RaceId = CharacterDTO.RaceId,
                ClassId = CharacterDTO.ClassId,
                Strength = CharacterDTO.Strength,
                HP = CharacterDTO.HP,
                Dex = CharacterDTO.Dex
            };
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task DeleteCharacter(int Id)
        {
            Character character = await _context.Characters.FindAsync(Id);
            _context.Entry(character).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
