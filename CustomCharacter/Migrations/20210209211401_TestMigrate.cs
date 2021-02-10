using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomCharacter.Migrations
{
    public partial class TestMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_AbilityId",
                table: "RaceAbilities",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAbilities_Abilities_AbilityId",
                table: "RaceAbilities",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_Abilities_AbilityId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_AbilityId",
                table: "RaceAbilities");
        }
    }
}
