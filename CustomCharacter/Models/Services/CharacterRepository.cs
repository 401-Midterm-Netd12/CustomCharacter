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
            CharacterDTO newCharacterDTO = await _context.Characters
                                    .Where(c => c.Id == Id)
                                    .Select(c => new CharacterDTO()
                                    {
                                        Id = c.Id,
                                        ClassId = c.ClassId,
                                        RaceId = c.RaceId,
                                        UserId = c.UserId,
                                        Name = c.Name,
                                        HP = c.HP,
                                        Dex = c.Dex,
                                        Strength = c.Strength,
                                        CharClassDTO = new ClassDTO()
                                        {
                                            Id = c.CharClass.Id,
                                            statModifier = c.CharClass.StatModifier,
                                            ClassName = c.CharClass.ClassNames,
                                            Skills = c.CharClass.ClassSkills
                                                                .Select(cs => new ClassSkill()
                                                                {
                                                                    ClassId = cs.ClassId,
                                                                    SkillId = cs.SkillId,
                                                                    SkillNav = new Skill()
                                                                                {
                                                                                    Id = cs.SkillNav.Id,
                                                                                    Name = cs.SkillNav.Name,
                                                                                    Desc = cs.SkillNav.Desc
                                                                                }
                                                                              
                                                                })
                                                                .ToList()
                                        },
                                        CharRaceDTO = new RaceDTO()
                                        {
                                            Id = c.CharRace.Id,
                                            RaceType = c.CharRace.RaceType,
                                            StatModifer = c.CharRace.StatModifier,
                                            DTOAbilities = c.CharRace.Abilities
                                                            .Select(a => new RaceAbility()
                                                            {
                                                                AbilityId = a.AbilityId,
                                                                RaceId = a.RaceId,
                                                                AbilityInRace = new Ability()
                                                                {
                                                                    Id = a.AbilityInRace.Id,
                                                                    Name = a.AbilityInRace.Name,
                                                                    Desc = a.AbilityInRace.Desc
                                                                }

                                                                
                                                            })
                                                            .ToList()
                                        }

                                    }).FirstOrDefaultAsync();
            //Character character = await _context.Characters.FindAsync(Id);

            //CharacterDTO characterDTO = new CharacterDTO()
            //{
            //    Id = Id,
            //    Name = character.Name,
            //    UserId = character.UserId,
            //    RaceId = character.RaceId,
            //    ClassId = character.ClassId,
            //    Strength = character.Strength,
            //    HP = character.HP,
            //    Dex = character.Dex
            //};

            ////TODO: Get abilities and skills form race and class
            return newCharacterDTO;
        }

        public async Task<List<CharacterDTO>> GetCharacters()
        {
            var newCharacterDTO = await _context.Characters
                                    .Select(c => new CharacterDTO()
                                    {
                                        Id = c.Id,
                                        ClassId = c.ClassId,
                                        RaceId = c.RaceId,
                                        UserId = c.UserId,
                                        Name = c.Name,
                                        HP = c.HP,
                                        Dex = c.Dex,
                                        Strength = c.Strength,
                                        CharClassDTO = new ClassDTO()
                                        {
                                            Id = c.CharClass.Id,
                                            statModifier = c.CharClass.StatModifier,
                                            ClassName = c.CharClass.ClassNames,
                                            Skills = c.CharClass.ClassSkills
                                                                .Select(cs => new ClassSkill()
                                                                {
                                                                    ClassId = cs.ClassId,
                                                                    SkillId = cs.SkillId,
                                                                    SkillNav = new Skill()
                                                                    {
                                                                        Id = cs.SkillNav.Id,
                                                                        Name = cs.SkillNav.Name,
                                                                        Desc = cs.SkillNav.Desc
                                                                    }

                                                                })
                                                                .ToList()
                                        },
                                        CharRaceDTO = new RaceDTO()
                                        {
                                            Id = c.CharRace.Id,
                                            RaceType = c.CharRace.RaceType,
                                            StatModifer = c.CharRace.StatModifier,
                                            DTOAbilities = c.CharRace.Abilities
                                                            .Select(a => new RaceAbility()
                                                            {
                                                                AbilityId = a.AbilityId,
                                                                RaceId = a.RaceId,
                                                                AbilityInRace = new Ability()
                                                                {
                                                                    Id = a.AbilityInRace.Id,
                                                                    Name = a.AbilityInRace.Name,
                                                                    Desc = a.AbilityInRace.Desc
                                                                }


                                                            })
                                                            .ToList()
                                        }

                                    }).ToListAsync();
            return newCharacterDTO;

            //var characters = await _context.Characters.ToListAsync();
            //var charaterList = new List<CharacterDTO>();

            //foreach(var items in characters)
            //{
            //    charaterList.Add(await GetCharacter(items.Id));
            //}
            //return charaterList;
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
