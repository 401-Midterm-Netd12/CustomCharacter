using CustomCharacter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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









            seedRole(modelBuilder, "DungeonMaster", "create", "update", "delete");
            seedRole(modelBuilder, "Creator", "create", "update");
            seedRole(modelBuilder, "Player", "create");
        }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ClassSkill> ClassSkills { get; set; }



        public DbSet<RaceAbility> RaceAbilities { get; set; }




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
