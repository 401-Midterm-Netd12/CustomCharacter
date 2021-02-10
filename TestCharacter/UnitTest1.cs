using CustomCharacter.Models;
using CustomCharacter.Models.API;
using CustomCharacter.Models.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestCharacter
{
    public class UnitTest1 : Mock
    {
        //[Fact]
        //public async Task CanCreateandSaveCharacter()
        //{
            //var newChar = CreateandSaveCharacter();

            //var repository = new CharacterRepository(_db);

            //await repository.Create(newChar);

            //var actualChar = await repository.GetCharacter(newChar.Id);
        //}

        [Fact]
        public async Task CanCreateandSaveAbilities()
        {
            var ability = CreateandSaveAbility();
            var repository = new AbilityRepository(_db);

            AbilityDTO dtoability = new AbilityDTO
            {
                Id = ability.Id,
                Name = "test",
                Desc = "test"
            };

            Ability testability = await repository.Create(dtoability);
            var actualAbility = await repository.GetAbility(testability.Id);

            Assert.Equal(actualAbility.Id, ability.Id);
            Assert.NotNull(ability);
            Assert.Equal(typeof(AbilityDTO), actualAbility.GetType());
            Assert.Equal("test", actualAbility.Name);
        }

        [Fact]
        public async Task CanCreateandSaveSkills()
        {
            var skill = CreateandSaveSkill();
            var repository = new SkillRepository(_db);

            SkillDTO dtoskill = new SkillDTO
            {
                Id = skill.Id,
                Name = "test",
                Desc = "test"
            };

            Skill testSkill = await repository.Create(dtoskill);
            var actualSkill = await repository.GetSkill(testSkill.Id);

            Assert.Equal(actualSkill.Id, skill.Id);
            Assert.NotNull(skill);
            Assert.Equal(typeof(SkillDTO), actualSkill.GetType());
            Assert.Equal("test", testSkill.Desc);
        }

        [Fact]
        public async Task CanCreateandSaveRace()
        {
            var race = CreateandSaveRace();
            var repository = new RaceRepository(_db);

            RaceDTO dtorace = new RaceDTO
            {
                //Id = race.Id,
                DTOAbilities = new List<RaceAbility> { },
                RaceType = "Human",
                StatModifer = 1,
            };

            Race testrace = await repository.CreateRace(dtorace);
            var actualrace = await repository.GetRace(testrace.Id);

            Assert.Equal(actualrace.Id, race.Id);
            Assert.NotNull(race);
            Assert.Equal(typeof(Race), actualrace.GetType());
        }

        [Fact]
        public async Task CanCreateandSaveClass()
        {
            var newClass = CreateandSaveClass();
            var repository = new ClassRepository(_db);

            ClassDTO dtoclass = new ClassDTO
            {
                Id = newClass.Id,
                ClassName = "Knight",
                StatModifier = 1,
                Skills = new List<ClassSkill> { }
            };

            Class testClass = await repository.CreateClass(dtoclass);
            var actualClass = await repository.GetClass(testClass.Id);

            Assert.Equal(actualClass.Id, dtoclass.Id);
            Assert.NotNull(newClass);
            Assert.Equal(typeof(Class), actualClass.GetType());
        }

        [Fact]
        public async Task CanAddandRemoveSkillToClass()
        {
            var newClass = CreateandSaveClass();
            var skill = CreateandSaveSkill();
            var repository = new ClassRepository(_db);

            ClassDTO dtoclass = new ClassDTO
            {
                Id = newClass.Id,
                ClassName = "Unicorn",
                StatModifier = 1,
                Skills = new List<ClassSkill> { }
            };

            Class testClass = await repository.CreateClass(dtoclass);
            var actualClass = await repository.GetClass(testClass.Id);

            await repository.AddAbilityToClass(newClass.Id, skill.Id); //this makes a classSkill

            Assert.Contains(actualClass.Skills, e => e.ClassId == newClass.Id);

            await repository.RemoveAbilityFromClass(actualClass.Id, skill.Id);
            Assert.DoesNotContain(actualClass.Skills, e => e.ClassId == newClass.Id);
        }

        [Fact]
        public async Task CanAddandRemoveAbilityToRace()
        {
            var race = CreateandSaveRace();
            var ability = CreateandSaveAbility();
            var repository = new RaceRepository(_db);

            RaceDTO dtorace = new RaceDTO
            {
                Id = race.Id,
                RaceType = "Hobit",
                StatModifer = 1,
                DTOAbilities = new List<RaceAbility> { },
            };

            Race testrace = await repository.CreateRace(dtorace);
            var actualrace = await repository.GetRace(testrace.Id);

            await repository.AddAbilityToRace(race.Id, ability.Id);

            Assert.Contains(actualrace.Abilities, e => e.RaceId == race.Id);

            await repository.RemoveAbilityFromRace(actualrace.Id, ability.Id);
            Assert.DoesNotContain(actualrace.Abilities, e => e.RaceId == race.Id);

        }
    }
}
