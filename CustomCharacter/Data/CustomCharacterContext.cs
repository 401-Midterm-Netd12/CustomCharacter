using CustomCharacter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CustomCharacter.Models.Class;
using static CustomCharacter.Models.Race;

namespace CustomCharacter.Data
{
    public class CustomCharacterContext : IdentityDbContext<AppUser>
    {
        public CustomCharacterContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassSkill>().HasKey(x => new { x.ClassId, x.SkillId });
            modelBuilder.Entity<RaceAbility>().HasKey(x => new { x.RaceId, x.AbilityId });

            //add some data


            seedRole(modelBuilder, "DungeonMaster", "create", "update", "delete");
            seedRole(modelBuilder, "Creator", "create", "update");
            seedRole(modelBuilder, "Player", "create");

            
            //modelBuilder.Entity<Character>().HasData(new Character
            //{
            //    Id = 1,
            //    UserId = "fedeed64-6693-4508-8e0e-ec41c9400da6",
            //    RaceId = 1,
            //    ClassId = 1,
            //    Name = "Bob's guy",
            //    HP = 10,
            //    Strength = 10,
            //    Dex = 2
            //});
            //modelBuilder.Entity<Race>().HasData(new Race
            //{
            //    Id = 1,
            //    RaceType = RaceTypes.Human,
            //    StatModifier = 2
            //});
            //modelBuilder.Entity<Class>().HasData(new Class
            //{
            //    Id = 1,
            //    ClassName = "Barbarian",
            //    StatModifier = 2
            //});
            //modelBuilder.Entity<RaceAbility>().HasData(new RaceAbility
            //{
            //    RaceId = 1,
            //    AbilityId = 1
            //});
            //modelBuilder.Entity<ClassSkill>().HasData(new ClassSkill
            //{
            //    ClassId = 1,
            //    SkillId = 1
            //});
            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = 1,
            //    RaceId = 1,
            //    Name = "Beer Breath",
            //    Desc = "Deadly stank breath."            
            //});
            //modelBuilder.Entity<Skill>().HasData(new Skill
            //{
            //    Id = 1,
            //    ClassId = 1,
            //    Name = "Swaggered walk",
            //    Desc = "Can drunkenly dodge attacks."
            //});

        }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<RaceAbility> RaceAbilities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ClassSkill> ClassSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }




        private int id = 1;
        private void seedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            var roleClaims = permissions.Select(permission =>
                new IdentityRoleClaim<string>
                {
                    Id = id++,
                    RoleId = role.Id,
                    ClaimType = "permissions",
                    ClaimValue = permission
                }
            );
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}
