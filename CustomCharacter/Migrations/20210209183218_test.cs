using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomCharacter.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceDTOId",
                table: "RaceAbilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassDTOId",
                table: "ClassSkills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharAppUserDTOId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharClassDTOId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharRaceDTOId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserDTO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDTO", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_RaceAbilities_RaceDTOId",
                table: "RaceAbilities",
                column: "RaceDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSkills_ClassDTOId",
                table: "ClassSkills",
                column: "ClassDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharAppUserDTOId",
                table: "Characters",
                column: "CharAppUserDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharClassDTOId",
                table: "Characters",
                column: "CharClassDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharRaceDTOId",
                table: "Characters",
                column: "CharRaceDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AppUserDTO_CharAppUserDTOId",
                table: "Characters",
                column: "CharAppUserDTOId",
                principalTable: "AppUserDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ClassDTO_CharClassDTOId",
                table: "Characters",
                column: "CharClassDTOId",
                principalTable: "ClassDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_RaceDTO_CharRaceDTOId",
                table: "Characters",
                column: "CharRaceDTOId",
                principalTable: "RaceDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSkills_ClassDTO_ClassDTOId",
                table: "ClassSkills",
                column: "ClassDTOId",
                principalTable: "ClassDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceDTOId",
                table: "RaceAbilities",
                column: "RaceDTOId",
                principalTable: "RaceDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AppUserDTO_CharAppUserDTOId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ClassDTO_CharClassDTOId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_RaceDTO_CharRaceDTOId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSkills_ClassDTO_ClassDTOId",
                table: "ClassSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceAbilities_RaceDTO_RaceDTOId",
                table: "RaceAbilities");

            migrationBuilder.DropTable(
                name: "AppUserDTO");

            migrationBuilder.DropTable(
                name: "ClassDTO");

            migrationBuilder.DropTable(
                name: "RaceDTO");

            migrationBuilder.DropIndex(
                name: "IX_RaceAbilities_RaceDTOId",
                table: "RaceAbilities");

            migrationBuilder.DropIndex(
                name: "IX_ClassSkills_ClassDTOId",
                table: "ClassSkills");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharAppUserDTOId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharClassDTOId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharRaceDTOId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RaceDTOId",
                table: "RaceAbilities");

            migrationBuilder.DropColumn(
                name: "ClassDTOId",
                table: "ClassSkills");

            migrationBuilder.DropColumn(
                name: "CharAppUserDTOId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharClassDTOId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharRaceDTOId",
                table: "Characters");
        }
    }
}
