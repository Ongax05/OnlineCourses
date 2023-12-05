using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Percistency.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlternativeKeysRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Qualidication_CourseId_UserId",
                table: "Qualidication");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Comment_CourseId_UserId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Qualidication_CourseId",
                table: "Qualidication",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CourseId",
                table: "Comment",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Qualidication_CourseId",
                table: "Qualidication");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CourseId",
                table: "Comment");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Qualidication_CourseId_UserId",
                table: "Qualidication",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Comment_CourseId_UserId",
                table: "Comment",
                columns: new[] { "CourseId", "UserId" });
        }
    }
}
