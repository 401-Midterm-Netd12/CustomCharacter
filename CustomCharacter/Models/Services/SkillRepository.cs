using CustomCharacter.Data;
using CustomCharacter.Models.API;
using CustomCharacter.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCharacter.Models.Services
{
    public class SkillRepository : ISkill
    {
        private readonly CustomCharacterContext _context;

        public SkillRepository(CustomCharacterContext context)
        {
            _context = context;
        }


        public async Task<Skill> Create(SkillDTO SkillDTO)
        {
            Skill Skill = new Skill()
            {
                Id = SkillDTO.Id,
                Desc = SkillDTO.Desc,
                Name = SkillDTO.Name,
            };

            _context.Entry(Skill).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return Skill;
        }

        public async Task<List<SkillDTO>> GetSkills()
        {
            var skills = await _context.Skills.ToListAsync();
            var SkillList = new List<SkillDTO>();

            foreach (var Skill in skills)
                SkillList.Add(await GetSkill(Skill.Id));

            return SkillList;
        }

        public async Task<SkillDTO> GetSkill(int Id)
        {
            Skill Skill = await _context.Skills.FindAsync(Id);

            SkillDTO SkillDTO = new SkillDTO()
            {
                Id = Skill.Id,
                Name = Skill.Name,
                Desc = Skill.Desc
            };

            return SkillDTO;
        }


        public async Task<Skill> UpdateSkill(int Id, SkillDTO SkillDTO)
        {
            Skill Skill = new Skill()
            {
                Id = SkillDTO.Id,
                Name = SkillDTO.Name,
                Desc = SkillDTO.Desc,
            };
            _context.Entry(Skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Skill;
        }

        public async Task DeleteSkill(int Id)
        {
            Skill Skill = await _context.Skills.FindAsync(Id);
            _context.Entry(Skill).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
