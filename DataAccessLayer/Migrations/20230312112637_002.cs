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
            migrationBuilder.CreateTable(
                name: "BranchBranch",
                columns: table => new
                {
                    BranchesListName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListBranchesName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchBranch", x => new { x.BranchesListName, x.ListBranchesName });
                    table.ForeignKey(
                        name: "FK_BranchBranch_Branches_BranchesListName",
                        column: x => x.BranchesListName,
                        principalTable: "Branches",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchBranch_Branches_ListBranchesName",
                        column: x => x.ListBranchesName,
                        principalTable: "Branches",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchBranch_ListBranchesName",
                table: "BranchBranch",
                column: "ListBranchesName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchBranch");
        }
    }
}
