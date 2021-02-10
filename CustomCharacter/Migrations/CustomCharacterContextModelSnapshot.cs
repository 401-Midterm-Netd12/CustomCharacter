﻿// <auto-generated />
using System;
using CustomCharacter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomCharacter.Migrations
{
    [DbContext(typeof(CustomCharacterContext))]
    partial class CustomCharacterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomCharacter.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Abilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Deadly stank breath.",
                            Name = "Beer Breath",
                            RaceId = 1
                        });
                });

            modelBuilder.Entity("CustomCharacter.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CustomCharacter.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Dex")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharAppUserId");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            Dex = 2,
                            HP = 10,
                            Name = "Bob's guy",
                            RaceId = 1,
                            Strength = 10,
                            UserId = "fedeed64-6693-4508-8e0e-ec41c9400da6"
                        });
                });

            modelBuilder.Entity("CustomCharacter.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassNames")
                        .HasColumnType("int");

                    b.Property<int>("StatModifier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassNames = 1,
                            StatModifier = 2
                        });
                });

            modelBuilder.Entity("CustomCharacter.Models.ClassSkill", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ClassSkills");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            SkillId = 1
                        });
                });

            modelBuilder.Entity("CustomCharacter.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RaceType")
                        .HasColumnType("int");

                    b.Property<int>("StatModifier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RaceType = 3,
                            StatModifier = 2
                        });
                });

            modelBuilder.Entity("CustomCharacter.Models.RaceAbility", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("RaceId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("RaceAbilities");

                    b.HasData(
                        new
                        {
                            RaceId = 1,
                            AbilityId = 1
                        });
                });

            modelBuilder.Entity("CustomCharacter.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            Desc = "Can drunkenly dodge attacks.",
                            Name = "Swaggered walk"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "dungeonmaster",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "DungeonMaster",
                            NormalizedName = "DUNGEONMASTER"
                        },
                        new
                        {
                            Id = "creator",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Creator",
                            NormalizedName = "CREATOR"
                        },
                        new
                        {
                            Id = "player",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Player",
                            NormalizedName = "PLAYER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "dungeonmaster"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "dungeonmaster"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "permissions",
                            ClaimValue = "delete",
                            RoleId = "dungeonmaster"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "creator"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "creator"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "player"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CustomCharacter.Models.Character", b =>
                {
                    b.HasOne("CustomCharacter.Models.AppUser", "CharAppUser")
                        .WithMany()
                        .HasForeignKey("CharAppUserId");

                    b.HasOne("CustomCharacter.Models.Class", "CharClass")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomCharacter.Models.Race", "CharRace")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomCharacter.Models.ClassSkill", b =>
                {
                    b.HasOne("CustomCharacter.Models.Class", "ClassNav")
                        .WithMany("ClassSkills")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomCharacter.Models.Skill", "SkillNav")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomCharacter.Models.RaceAbility", b =>
                {
                    b.HasOne("CustomCharacter.Models.Ability", "AbilityInRace")
                        .WithMany("AbilityList")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomCharacter.Models.Race", "RaceInRace")
                        .WithMany("Abilities")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CustomCharacter.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CustomCharacter.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomCharacter.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CustomCharacter.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
