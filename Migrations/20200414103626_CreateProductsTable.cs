using Microsoft.EntityFrameworkCore.Migrations;

namespace Grocery.Migrations
{
    public partial class CreateProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProdID = table.Column<long>(type: "BigInt", nullable: false),
                    ProdNum = table.Column<string>(type: "nVarChar(20)", maxLength: 20, nullable: false),
                    ProdName = table.Column<string>(type: "nVarChar(100)", maxLength: 100, nullable: false),
                    ProdDesc = table.Column<string>(type: "nVarChar(200)", maxLength: 200, nullable: false),
                    ProdNotes = table.Column<string>(type: "nVarChar(512)", maxLength: 512, nullable: true),
                    ProdImageName = table.Column<string>(type: "nVarChar(200)", maxLength: 200, nullable: true),
                    ProdCategoryID = table.Column<long>(type: "BigInt", nullable: false),
                    ProdBrandID = table.Column<long>(type: "BigInt", nullable: false),
                    UOMID = table.Column<long>(type: "BigInt", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProdID);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrand_ProductBrandProdBrandID",
                        column: x => x.ProdBrandID,
                        principalTable: "ProductBrand",
                        principalColumn: "ProdBrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_ProductCategoryProdCategoryID",
                        column: x => x.ProdCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "ProdCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_UnitsOfMeasurement_UnitsOfMeasurementUOMID",
                        column: x => x.UOMID,
                        principalTable: "UnitsOfMeasurement",
                        principalColumn: "UOMID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdBrandID",
                table: "Products",
                column: "ProdBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdCategoryID",
                table: "Products",
                column: "ProdCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UOMID",
                table: "Products",
                column: "UOMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
