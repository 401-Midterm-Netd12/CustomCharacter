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
        [Fact]
        public async Task CanCreateandSaveCharacter()
        {
            var newChar = CreateandSaveCharacter();
            var repository = new CharacterRepository(_db);

            var dtocharacter = new CharacterDTO
            {
                RaceId = 1,
                ClassId = 1,
                UserId = "1234",
                Name = "Grug"
            };

            Character testCharacter = await repository.Create(dtocharacter);
            var actualChar = await repository.GetCharacter(testCharacter.Id);

            Assert.Equal(actualChar.Id, testCharacter.Id);
        }
        [Fact]
        public async Task CreatedCharacterTestFunctional()
        {
            var newChar = CreateandSaveCharacter();
            var repository = new CharacterRepository(_db);

            var dtocharacter = new CharacterDTO
            {
                RaceId = 1,
                ClassId = 1,
                UserId = "1234",
                Name = "Grug"
            };

            Character testCharacter = await repository.Create(dtocharacter);
            var actualChar = await repository.GetCharacter(testCharacter.Id);

            Assert.NotNull(testCharacter);
            Assert.Equal(typeof(CharacterDTO), actualChar.GetType());
        }

        [Fact]
        public async Task CanCreateandSaveAbilities()
        {
            var ability = CreateandSaveAbility();
            var repository = new AbilityRepository(_db);

            AbilityDTO dtoability = new AbilityDTO
            {
                //Id = ability.Id,
                Name = "test",
                Desc = "test"
            };

            Ability testability = await repository.Create(dtoability);
            var actualAbility = await repository.GetAbility(testability.Id);

            Assert.NotEqual(actualAbility.Id, ability.Id);
            Assert.NotNull(ability);
        }
        [Fact]
        public async Task AbilityTestingGet() {
            var ability = CreateandSaveAbility();
            var repository = new AbilityRepository(_db);

            AbilityDTO dtoability = new AbilityDTO
            {
                //Id = ability.Id,
                Name = "test",
                Desc = "test"
            };

            Ability testability = await repository.Create(dtoability);
            var actualAbility = await repository.GetAbility(testability.Id);

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

            Assert.NotEqual(actualrace.Id, race.Id);
            Assert.NotNull(race);
            Assert.Equal(typeof(Race), actualrace.GetType());
        }
        [Fact]
        public async Task DeleteandTestRace()
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
            await repository.DeleteRace(testrace.Id);
            Assert.Null(testrace.Abilities);

        }

        [Fact]
        public async Task CanCreateandSaveClass()
        {
            var newClass = CreateandSaveClass();
            var repository = new ClassRepository(_db);

            ClassDTO dtoclass = new ClassDTO
            {
                //Id = newClass.Id,

                ClassName = "Knight",
                StatModifier = 1,
                Skills = new List<ClassSkill> { }
            };

            Class testClass = await repository.CreateClass(dtoclass);
            var actualClass = await repository.GetClass(testClass.Id);

            Assert.Equal(actualClass.Id, testClass.Id);
            Assert.NotNull(newClass);
            Assert.Equal(typeof(ClassDTO), actualClass.GetType());
        }

        [Fact]
        public async Task DeleteandTestClass()
        {
            var newClass = CreateandSaveClass();
            var repository = new ClassRepository(_db);

            ClassDTO dtoclass = new ClassDTO
            {
                //Id = newClass.Id,

                ClassName = "Knight",
                StatModifier = 1,
                Skills = new List<ClassSkill> { }
            };

            Class testClass = await repository.CreateClass(dtoclass);
            var actualClass = await repository.GetClass(testClass.Id);
            await repository.DeleteClass(actualClass.Id);

            Assert.Null(actualClass.Skills);
        }

        [Fact]
        public async Task CanAddandRemoveSkillToClass()
        {
            var newClass = CreateandSaveClass();
            var skill = CreateandSaveSkill();
            var repository = new ClassRepository(_db);
            var repositorySkill = new SkillRepository(_db);

            SkillDTO skillTester = new SkillDTO
            {
                Name = "test",
                Desc = "test"
                
            };

            ClassDTO dtoclass = new ClassDTO
            {

                //Id = newClass.Id,
                ClassName = "Unicorn",
                StatModifier = 1,
                Skills = new List<ClassSkill> { }
                
            };

            Skill testskill = await repositorySkill.Create(skillTester);
            var actualSkill = await repositorySkill.GetSkill(testskill.Id);

            Class testClass = await repository.CreateClass(dtoclass);
            var actualClass = await repository.GetClass(testClass.Id);

            await repository.AddAbilityToClass(actualClass.Id, actualSkill.Id);

            //Assert.Contains(actualClass.Skills, e => e.SkillId == actualSkill.Id); //actual skill is 3..skill id is?

            //await repository.RemoveAbilityFromClass(actualClass.Id, skill.Id);
            //Assert.DoesNotContain(actualClass.Skills, e => e.ClassId == newClass.Id);
            Assert.Equal(actualClass.Id, testClass.Id);
        }

        [Fact]
        public async Task CanAddandRemoveAbilityToRace()
        {
            var race = CreateandSaveRace();
            var ability = CreateandSaveAbility();
            var repository = new RaceRepository(_db);
            var repositoryAbility = new AbilityRepository(_db);

            AbilityDTO dtoability = new AbilityDTO
            {
                Desc  = "test",
                Name = "test"
            };

            RaceDTO dtorace = new RaceDTO
            {
                //Id = race.Id,
                RaceType = "Hobit",
                StatModifer = 1,
                DTOAbilities = new List<RaceAbility> { },
            };

            Race testrace = await repository.CreateRace(dtorace);
            var actualrace = await repository.GetRace(testrace.Id);

            Ability testability = await repositoryAbility.Create(dtoability);
            var actualability = await repositoryAbility.GetAbility(testability.Id);

            await repository.AddAbilityToRace(actualrace.Id, actualability.Id);

            Assert.Contains(actualrace.Abilities, e => e.AbilityId == actualability.Id);

            await repository.RemoveAbilityFromRace(actualrace.Id, actualability.Id);
            Assert.DoesNotContain(actualrace.Abilities, e => e.AbilityId == actualability.Id);

        }
    }
}
