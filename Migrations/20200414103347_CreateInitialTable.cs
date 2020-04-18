using Microsoft.EntityFrameworkCore.Migrations;

namespace Grocery.Migrations
{
    public partial class CreateInitialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    ProdBrandID = table.Column<long>(type: "BigInt", nullable: false),
                    ProdBrandName = table.Column<string>(type: "nVarChar(50)", maxLength: 50, nullable: false),
                    ProdBrandDesc = table.Column<string>(type: "nVarChar(70)", maxLength: 70, nullable: true),
                    ProdBrandIndex = table.Column<int>(type: "Int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.ProdBrandID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProdCategoryID = table.Column<long>(type: "BigInt", nullable: false),
                    ProdCategoryName = table.Column<string>(type: "nVarChar(30)", maxLength: 30, nullable: false),
                    ProdCategoryDesc = table.Column<string>(type: "nVarChar(50)", maxLength: 50, nullable: true),
                    ProdCategoryIndex = table.Column<int>(type: "Int", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProdCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasurement",
                columns: table => new
                {
                    UOMID = table.Column<long>(type: "BigInt", nullable: false),
                    UOMName = table.Column<string>(type: "nVarChar(10)", maxLength: 10, nullable: false),
                    UOMDesc = table.Column<string>(type: "nVarChar(40)", maxLength: 40, nullable: true),
                    UOMIndex = table.Column<int>(type: "Int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasurement", x => x.UOMID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasurement");
        }
    }
}
