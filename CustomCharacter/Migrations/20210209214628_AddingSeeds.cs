using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomCharacter.Migrations
{
    public partial class AddingSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_AbilityDTO_AbilityListId",
                table: "RaceAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceListId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_AbilityListId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_RaceListId",
                table: "RaceAbilities");

            migrationBuilder.DropColumn(
                name: "AbilityListId",
                table: "RaceAbilities");

            migrationBuilder.DropColumn(
                name: "RaceListId",
                table: "RaceAbilities");

            migrationBuilder.AddColumn<int>(
                name: "AbilityInRaceId",
                table: "RaceAbilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceInRaceId",
                table: "RaceAbilities",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Desc", "Name", "RaceId" },
                values: new object[] { 1, "Deadly stank breath.", "Beer Breath", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "cad8346b-f4c5-477d-b300-4b7c8000c9c5", null, false, false, null, null, null, null, null, false, "7b5e7cf2-4b96-4e10-876f-180f009e6b51", false, "Bob" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassNames", "StatModifier" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "RaceType", "StatModifier" },
                values: new object[] { 1, 3, 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ClassId", "Desc", "Name" },
                values: new object[] { 1, 1, "Can drunkenly dodge attacks.", "Swaggered walk" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "CharAppUserId", "ClassId", "Dex", "HP", "Name", "RaceId", "Strength", "UserId" },
                values: new object[] { 1, null, 1, 2, 10, "Bob's guy", 1, 10, "1" });

            migrationBuilder.InsertData(
                table: "ClassSkills",
                columns: new[] { "ClassId", "SkillId", "ClassNavId" },
                values: new object[] { 1, 1, null });

            migrationBuilder.InsertData(
                table: "RaceAbilities",
                columns: new[] { "RaceId", "AbilityId", "AbilityInRaceId", "RaceInRaceId" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_AbilityInRaceId",
                table: "RaceAbilities",
                column: "AbilityInRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_RaceInRaceId",
                table: "RaceAbilities",
                column: "RaceInRaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAbilities_AbilityDTO_AbilityInRaceId",
                table: "RaceAbilities",
                column: "AbilityInRaceId",
                principalTable: "AbilityDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceInRaceId",
                table: "RaceAbilities",
                column: "RaceInRaceId",
                principalTable: "RaceDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_AbilityDTO_AbilityInRaceId",
                table: "RaceAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceInRaceId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_AbilityInRaceId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_RaceInRaceId",
                table: "RaceAbilities");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassSkills",
                keyColumns: new[] { "ClassId", "SkillId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RaceAbilities",
                keyColumns: new[] { "RaceId", "AbilityId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AbilityInRaceId",
                table: "RaceAbilities");

            migrationBuilder.DropColumn(
                name: "RaceInRaceId",
                table: "RaceAbilities");

            migrationBuilder.AddColumn<int>(
                name: "AbilityListId",
                table: "RaceAbilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceListId",
                table: "RaceAbilities",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_AbilityListId",
                table: "RaceAbilities",
                column: "AbilityListId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_RaceListId",
                table: "RaceAbilities",
                column: "RaceListId");

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
    }
}
