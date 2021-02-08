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
    public class ClassRepository : IClass
    {
        private readonly CustomCharacterContext _context;
        public ClassRepository(CustomCharacterContext context)
        {
            _context = context;
        }
        public async Task AddAbilityToClass(int classId, int abilityId)
        {
            ClassSkill ability = new ClassSkill()
            {
                ClassId = classId,
                SkillId = abilityId
            };
            _context.Entry(ability).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<ClassDTO> CreateClass(ClassDTO classDTO)
        {
            Class newClass = new Class()
            {
                Id = classDTO.Id,
                ClassSkills = classDTO.Skills.ToList(),
                StatModifier = classDTO.statModifier
            };
            _context.Entry(newClass).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return classDTO;
        }

        public async Task DeleteClass(int Id)
        {
            Class delete = await _context.Classes
                .FirstOrDefaultAsync(x => x.Id == Id);
            _context.Entry(delete).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Class> GetClass(int Id)
        {
            var result = await _context.Classes.Include(x => x.Id == Id).FirstOrDefaultAsync();

            ClassDTO dtoClass = new ClassDTO()
            {
                ClassName = result.ClassName,
                Id = Id,
                statModifier = result.StatModifier,
                Skills = result.ClassSkills.ToList()
            };
            return result;
        }

        public async Task<List<ClassDTO>> GetClasses()
        {
            var result = await _context.Classes.Include(x => x.Id).ToListAsync();
            return result
                .Select(stuff => new ClassDTO
                {
                    ClassName = stuff.ClassName,
                    Id = stuff.Id,
                    statModifier = stuff.StatModifier,
                    Skills = stuff.ClassSkills.ToList()
                }).ToList();
        }

        public async Task RemoveAbilityFromClass(int classId, int abilityId)
        {
            var result = await _context.ClassSkills.FirstOrDefaultAsync(x => x.ClassId == classId && x.SkillId == abilityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Class> UpdateClass(ClassDTO classDTO)
        {
            var result = await GetClass(classDTO.Id);
            result.Id = classDTO.Id;
            result.ClassName = classDTO.ClassName;
            result.StatModifier = classDTO.statModifier;
            result.ClassSkills = classDTO.Skills.ToList();

            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
