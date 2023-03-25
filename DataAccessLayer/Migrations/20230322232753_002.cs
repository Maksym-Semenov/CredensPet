using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressProjects_ProjectId",
                table: "AddressProjects");

            migrationBuilder.CreateIndex(
                name: "IX_AddressProjects_ProjectId",
                table: "AddressProjects",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressProjects_ProjectId",
                table: "AddressProjects");

            migrationBuilder.CreateIndex(
                name: "IX_AddressProjects_ProjectId",
                table: "AddressProjects",
                column: "ProjectId");
        }
    }
}
