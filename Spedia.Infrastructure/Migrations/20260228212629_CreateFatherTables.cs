using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spedia.Migrations
{
    /// <inheritdoc />
    public partial class CreateFatherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTBs_LevelTBs_LevelId",
                table: "StudentTBs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelTBs",
                table: "LevelTBs");

            migrationBuilder.RenameTable(
                name: "LevelTBs",
                newName: "LevelTB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelTB",
                table: "LevelTB",
                column: "LevelId");

            migrationBuilder.CreateTable(
                name: "StudentFather",
                columns: table => new
                {
                    StudentFatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFatherEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFatherPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFatherPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFather", x => x.StudentFatherId);
                    table.ForeignKey(
                        name: "FK_StudentFather_StudentTBs_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentTBs",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentFather_StudentId",
                table: "StudentFather",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTBs_LevelTB_LevelId",
                table: "StudentTBs",
                column: "LevelId",
                principalTable: "LevelTB",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTBs_LevelTB_LevelId",
                table: "StudentTBs");

            migrationBuilder.DropTable(
                name: "StudentFather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelTB",
                table: "LevelTB");

            migrationBuilder.RenameTable(
                name: "LevelTB",
                newName: "LevelTBs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelTBs",
                table: "LevelTBs",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTBs_LevelTBs_LevelId",
                table: "StudentTBs",
                column: "LevelId",
                principalTable: "LevelTBs",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
