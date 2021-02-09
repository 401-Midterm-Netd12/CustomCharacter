using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomCharacter.Migrations
{
    public partial class AddingNavToRaceAbility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbilityListId",
                table: "RaceAbilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceListId",
                table: "RaceAbilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassNavId",
                table: "ClassSkills",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbilityDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statModifier = table.Column<int>(nullable: false),
                    ClassName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceType = table.Column<int>(nullable: false),
                    StatModifer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    ClassSkillClassId = table.Column<int>(nullable: true),
                    ClassSkillSkillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillDTO_ClassSkills_ClassSkillClassId_ClassSkillSkillId",
                        columns: x => new { x.ClassSkillClassId, x.ClassSkillSkillId },
                        principalTable: "ClassSkills",
                        principalColumns: new[] { "ClassId", "SkillId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_AbilityListId",
                table: "RaceAbilities",
                column: "AbilityListId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_RaceListId",
                table: "RaceAbilities",
                column: "RaceListId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSkills_ClassNavId",
                table: "ClassSkills",
                column: "ClassNavId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillDTO_ClassSkillClassId_ClassSkillSkillId",
                table: "SkillDTO",
                columns: new[] { "ClassSkillClassId", "ClassSkillSkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSkills_ClassDTO_ClassNavId",
                table: "ClassSkills",
                column: "ClassNavId",
                principalTable: "ClassDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAbilities_AbilityDTO_AbilityListId",
                table: "RaceAbilities",
                column: "AbilityListId",
                principalTable: "AbilityDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceListId",
                table: "RaceAbilities",
                column: "RaceListId",
                principalTable: "RaceDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSkills_ClassDTO_ClassNavId",
                table: "ClassSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_AbilityDTO_AbilityListId",
                table: "RaceAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceListId",
                table: "RaceAbilities");

            migrationBuilder.DropTable(
                name: "AbilityDTO");

            migrationBuilder.DropTable(
                name: "ClassDTO");

            migrationBuilder.DropTable(
                name: "RaceDTO");

            migrationBuilder.DropTable(
                name: "SkillDTO");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_AbilityListId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_RaceListId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_ClassSkills_ClassNavId",
                table: "ClassSkills");

            migrationBuilder.DropColumn(
                name: "AbilityListId",
                table: "RaceAbilities");

            migrationBuilder.DropColumn(
                name: "RaceListId",
                table: "RaceAbilities");

            migrationBuilder.DropColumn(
                name: "ClassNavId",
                table: "ClassSkills");
        }
    }
}
