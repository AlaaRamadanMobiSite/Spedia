using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spedia.Migrations
{
    /// <inheritdoc />
    public partial class CreatStudentAndLevelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelTBs",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelTBs", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "StudentTBs",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTBs", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentTBs_LevelTBs_LevelId",
                        column: x => x.LevelId,
                        principalTable: "LevelTBs",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTBs_LevelId",
                table: "StudentTBs",
                column: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTBs");

            migrationBuilder.DropTable(
                name: "LevelTBs");
        }
    }
}
