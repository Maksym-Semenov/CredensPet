using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchBranch",
                table: "BranchBranch");

            migrationBuilder.DropIndex(
                name: "IX_BranchBranch_ListBranchesBranchName",
                table: "BranchBranch");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchesListBranchName",
                table: "BranchBranch");

            migrationBuilder.DropColumn(
                name: "ListBranchesBranchName",
                table: "BranchBranch");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Branches",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "BranchName",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BranchesListBranchId",
                table: "BranchBranch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListBranchesBranchId",
                table: "BranchBranch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchBranch",
                table: "BranchBranch",
                columns: new[] { "BranchesListBranchId", "ListBranchesBranchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchBranch_ListBranchesBranchId",
                table: "BranchBranch",
                column: "ListBranchesBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchBranch_Branches_BranchesListBranchId",
                table: "BranchBranch",
                column: "BranchesListBranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchBranch_Branches_ListBranchesBranchId",
                table: "BranchBranch",
                column: "ListBranchesBranchId",
                principalTable: "Branches",
                principalColumn: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchBranch_Branches_BranchesListBranchId",
                table: "BranchBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchBranch_Branches_ListBranchesBranchId",
                table: "BranchBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchBranch",
                table: "BranchBranch");

            migrationBuilder.DropIndex(
                name: "IX_BranchBranch_ListBranchesBranchId",
                table: "BranchBranch");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchesListBranchId",
                table: "BranchBranch");

            migrationBuilder.DropColumn(
                name: "ListBranchesBranchId",
                table: "BranchBranch");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "BranchName",
                table: "Branches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Branches",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BranchesListBranchName",
                table: "BranchBranch",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ListBranchesBranchName",
                table: "BranchBranch",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "BranchName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchBranch",
                table: "BranchBranch",
                columns: new[] { "BranchesListBranchName", "ListBranchesBranchName" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchName",
                table: "Users",
                column: "BranchName");

            migrationBuilder.CreateIndex(
                name: "IX_BranchBranch_ListBranchesBranchName",
                table: "BranchBranch",
                column: "ListBranchesBranchName");

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
    }
}
