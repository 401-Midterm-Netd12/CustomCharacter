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
            _context.Entry(ability).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<Class> CreateClass(ClassDTO classDTO)
        {
            Class newClass = new Class()
            {
                Id = classDTO.Id,
                StatModifier = classDTO.StatModifier,
                ClassName = classDTO.ClassName
            };
            _context.Entry(newClass).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newClass;
        }

        public async Task DeleteClass(int Id)
        {
            Class delete = await _context.Classes
                .FirstOrDefaultAsync(x => x.Id == Id);
            _context.Entry(delete).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ClassDTO> GetClass(int Id)
        {
            var result = await _context.Classes.Where(x => x.Id == Id).FirstOrDefaultAsync();

            ClassDTO dtoClass = new ClassDTO()
            {
                ClassName = result.ClassName,
                Id = Id,
                StatModifier = result.StatModifier,
            };
            return dtoClass;
        }

        public async Task<List<ClassDTO>> GetClasses()
        {
            var result = await _context.Classes.ToListAsync();

            return result
                .Select(stuff => new ClassDTO
                {
                    ClassName = stuff.ClassName,
                    Id = stuff.Id,
                    StatModifier = stuff.StatModifier,
                   
                }).ToList();
        }

        public async Task RemoveAbilityFromClass(int classId, int abilityId)
        {
            var result = await _context.ClassSkills.FirstOrDefaultAsync(x => x.ClassId == classId && x.SkillId == abilityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Class> UpdateClass(Class Class)
        {
            Class newClass = new Class()
            {
                Id = Class.Id,
                ClassName = Class.ClassName,
                StatModifier = Class.StatModifier,
            };

            _context.Entry(newClass).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newClass;
        }
    }
}
