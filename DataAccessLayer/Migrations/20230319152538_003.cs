using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactProjects_Projects_ContactProjectId",
                table: "ContactProjects");

            migrationBuilder.DropColumn(
                name: "ContactProjectId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ContactProjectId",
                table: "ContactProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactProjects_ProjectId",
                table: "ContactProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactProjects_Projects_ProjectId",
                table: "ContactProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactProjects_Projects_ProjectId",
                table: "ContactProjects");

            migrationBuilder.DropIndex(
                name: "IX_ContactProjects_ProjectId",
                table: "ContactProjects");

            migrationBuilder.AddColumn<int>(
                name: "ContactProjectId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ContactProjectId",
                table: "ContactProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactProjects_Projects_ContactProjectId",
                table: "ContactProjects",
                column: "ContactProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
