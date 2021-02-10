using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomCharacter.Migrations
{
    public partial class AddingNavInChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CharAppUserId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharAppUserId",
                table: "Characters",
                column: "CharAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RaceId",
                table: "Characters",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_CharAppUserId",
                table: "Characters",
                column: "CharAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Races_RaceId",
                table: "Characters",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_CharAppUserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Races_RaceId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharAppUserId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ClassId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_RaceId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharAppUserId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "RaceDTOId",
                table: "RaceAbilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassDTOId",
                table: "ClassSkills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharAppUserDTOId",
                table: "Characters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharClassDTOId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharRaceDTOId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserDTO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<int>(type: "int", nullable: false),
                    statModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceType = table.Column<int>(type: "int", nullable: false),
                    StatModifer = table.Column<int>(type: "int", nullable: false)
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
    }
}
