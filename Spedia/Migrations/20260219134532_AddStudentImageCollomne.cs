using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spedia.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentImageCollomne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentImage",
                table: "StudentTBs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentImage",
                table: "StudentTBs");
        }
    }
}
