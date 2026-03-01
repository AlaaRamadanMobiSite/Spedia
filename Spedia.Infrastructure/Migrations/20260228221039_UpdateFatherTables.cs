using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spedia.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFatherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFather_StudentTBs_StudentId",
                table: "StudentFather");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTBs_LevelTB_LevelId",
                table: "StudentTBs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentFather",
                table: "StudentFather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelTB",
                table: "LevelTB");

            migrationBuilder.RenameTable(
                name: "StudentFather",
                newName: "StudentFathers");

            migrationBuilder.RenameTable(
                name: "LevelTB",
                newName: "LevelTBs");

            migrationBuilder.RenameIndex(
                name: "IX_StudentFather_StudentId",
                table: "StudentFathers",
                newName: "IX_StudentFathers_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentFathers",
                table: "StudentFathers",
                column: "StudentFatherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelTBs",
                table: "LevelTBs",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFathers_StudentTBs_StudentId",
                table: "StudentFathers",
                column: "StudentId",
                principalTable: "StudentTBs",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTBs_LevelTBs_LevelId",
                table: "StudentTBs",
                column: "LevelId",
                principalTable: "LevelTBs",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentFathers_StudentTBs_StudentId",
                table: "StudentFathers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTBs_LevelTBs_LevelId",
                table: "StudentTBs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentFathers",
                table: "StudentFathers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelTBs",
                table: "LevelTBs");

            migrationBuilder.RenameTable(
                name: "StudentFathers",
                newName: "StudentFather");

            migrationBuilder.RenameTable(
                name: "LevelTBs",
                newName: "LevelTB");

            migrationBuilder.RenameIndex(
                name: "IX_StudentFathers_StudentId",
                table: "StudentFather",
                newName: "IX_StudentFather_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentFather",
                table: "StudentFather",
                column: "StudentFatherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelTB",
                table: "LevelTB",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentFather_StudentTBs_StudentId",
                table: "StudentFather",
                column: "StudentId",
                principalTable: "StudentTBs",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTBs_LevelTB_LevelId",
                table: "StudentTBs",
                column: "LevelId",
                principalTable: "LevelTB",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
