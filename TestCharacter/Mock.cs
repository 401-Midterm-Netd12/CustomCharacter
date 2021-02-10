using CustomCharacter.Data;
using CustomCharacter.Models;
using CustomCharacter.Models.API;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCharacter
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly CustomCharacterContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            _db = new CustomCharacterContext(
                new DbContextOptionsBuilder<CustomCharacterContext>()
                .UseSqlite(_connection)
                .Options);
            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        //Since our Character creation uses a DTO but our Characters expects non-dto I made both for now.
        protected async Task<Character> CreateandSaveCharacter()
        {
            var testChar = new Character
            {
                UserId = "fedeed64-6693-4508-8e0e-ec41c9400da6",
                RaceId = 1,
                ClassId = 1,
                Name = "Bob's guy",
                HP = 10,
                Strength = 10,
                Dex = 2
            };
            _db.Characters.Add(testChar);

            await _db.SaveChangesAsync();
            _db.Entry(testChar).State = EntityState.Detached;

            Assert.NotEqual(0, testChar.HP);
            return testChar;
        }

        protected async Task<Ability> CreateandSaveAbility()
        {
            var ability = new Ability
            {
                Desc = "Fireballs of death and....fire",
                Id = 4,
                Name = "Fireball",
            };
            _db.Abilities.Add(ability);
            await _db.SaveChangesAsync();
            _db.Entry(ability).State = EntityState.Detached;

            Assert.NotNull(ability);
            return ability;
        }
        protected async Task<RaceAbility> CreateandSaveRaceAbility()
        {
            var Raceability = new RaceAbility
            {
                AbilityId = 6,
                RaceId = 6,
                AbilityInRace = new Ability { },
                RaceInRace = new Race { }
            };
            _db.RaceAbilities.Add(Raceability);
            await _db.SaveChangesAsync();
            _db.Entry(Raceability).State = EntityState.Detached;

            Assert.NotEqual(0, Raceability.AbilityId);
            return Raceability;
        }

        protected async Task<Skill> CreateandSaveSkill()
        {
            var skill = new Skill
            {
                Desc = "You can now see in the night!",
                Name = "NightSight",
                //ClassId = 5,
            };
            _db.Skills.Add(skill);
            await _db.SaveChangesAsync();
            _db.Entry(skill).State = EntityState.Detached;

            Assert.NotNull(skill.Name);
            return skill;
        }

        protected async Task<ClassSkill> CreateandSaveClassSKill()
        {
            var classSkill = new ClassSkill
            {
                ClassId = 88,
                SkillId = 22,
                ClassNav = new Class { },
                SkillNav = new Skill { }
            };
            _db.ClassSkills.Add(classSkill);
            await _db.SaveChangesAsync();
            _db.Entry(classSkill).State = EntityState.Detached;

            Assert.NotEqual(0, classSkill.ClassId);
            return classSkill;
        }

        protected async Task<Race> CreateandSaveRace()
        {
            var race = new Race
            {
                RaceType = "Monke",
                Abilities = new List<RaceAbility> { },
                StatModifier = 3
            };
            _db.Races.Add(race);
            await _db.SaveChangesAsync();
            _db.Entry(race).State = EntityState.Deleted;

            Assert.NotNull(race);
            return race;
        }

        protected async Task<Class> CreateandSaveClass()
        {
            var testClass = new Class
            {
                //Id = 88,
                StatModifier = 2,
                ClassNames = "Paladin",
                ClassSkills = new List<ClassSkill> { }
            };
            _db.Classes.Add(testClass);
            await _db.SaveChangesAsync();
            _db.Entry(testClass).State = EntityState.Deleted;

            Assert.NotNull(testClass);
            return testClass;
        }
    }
}
