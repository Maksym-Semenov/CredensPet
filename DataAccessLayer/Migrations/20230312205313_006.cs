using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchBranch_Branches_BranchesListName",
                table: "BranchBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchBranch_Branches_ListBranchesName",
                table: "BranchBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "BranchName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Name",
                table: "Users",
                newName: "IX_Users_BranchName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Branches",
                newName: "BranchName");

            migrationBuilder.RenameColumn(
                name: "ListBranchesName",
                table: "BranchBranch",
                newName: "ListBranchesBranchName");

            migrationBuilder.RenameColumn(
                name: "BranchesListName",
                table: "BranchBranch",
                newName: "BranchesListBranchName");

            migrationBuilder.RenameIndex(
                name: "IX_BranchBranch_ListBranchesName",
                table: "BranchBranch",
                newName: "IX_BranchBranch_ListBranchesBranchName");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchBranch_Branches_BranchesListBranchName",
                table: "BranchBranch",
                column: "BranchesListBranchName",
                principalTable: "Branches",
                principalColumn: "BranchName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchBranch_Branches_ListBranchesBranchName",
                table: "BranchBranch",
                column: "ListBranchesBranchName",
                principalTable: "Branches",
                principalColumn: "BranchName");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchName",
                table: "Users",
                column: "BranchName",
                principalTable: "Branches",
                principalColumn: "BranchName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchBranch_Branches_BranchesListBranchName",
                table: "BranchBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchBranch_Branches_ListBranchesBranchName",
                table: "BranchBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BranchName",
                table: "Users",
                newName: "IX_Users_Name");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "Branches",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ListBranchesBranchName",
                table: "BranchBranch",
                newName: "ListBranchesName");

            migrationBuilder.RenameColumn(
                name: "BranchesListBranchName",
                table: "BranchBranch",
                newName: "BranchesListName");

            migrationBuilder.RenameIndex(
                name: "IX_BranchBranch_ListBranchesBranchName",
                table: "BranchBranch",
                newName: "IX_BranchBranch_ListBranchesName");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchBranch_Branches_BranchesListName",
                table: "BranchBranch",
                column: "BranchesListName",
                principalTable: "Branches",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchBranch_Branches_ListBranchesName",
                table: "BranchBranch",
                column: "ListBranchesName",
                principalTable: "Branches",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_Name",
                table: "Users",
                column: "Name",
                principalTable: "Branches",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
