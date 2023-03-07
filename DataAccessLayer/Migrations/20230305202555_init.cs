using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    OrderValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderMonth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderYear = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    OrderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResidentialComplex = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    TypeStreet = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Litera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuildingPart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apartment = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MakerId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)


                        
                },
                
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
