using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDocker.Migrations.All
{
    public partial class mysqlall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Finishings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CollectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finishings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CollectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<int>(nullable: false),
                    CollectionId = table.Column<int>(nullable: false),
                    FurnitureNameId = table.Column<int>(nullable: false),
                    FinishingId = table.Column<int>(nullable: false),
                    FurnitureTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<int>(nullable: false),
                    CollectionId = table.Column<int>(nullable: false),
                    FurnitureNameId = table.Column<int>(nullable: false),
                    FinishingId = table.Column<int>(nullable: false),
                    FurnitureTypeId = table.Column<int>(nullable: false),
                    StorekeeperComeNameId = table.Column<string>(nullable: true),
                    ManagerNameId = table.Column<string>(nullable: true),
                    AccountantNameId = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    StorekeeperGiveOutNameId = table.Column<string>(nullable: true),
                    ComeDocumentName = table.Column<string>(nullable: true),
                    ContractGiveOutName = table.Column<string>(nullable: true),
                    ScoreGiveOutName = table.Column<string>(nullable: true),
                    ComePrice = table.Column<decimal>(nullable: false),
                    GiveOutPrice = table.Column<decimal>(nullable: false),
                    ComeDataTime = table.Column<DateTime>(nullable: false),
                    GiveOutDataTime = table.Column<DateTime>(nullable: false),
                    ProductListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BrandCollections",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[] { 1, 1, "Florence" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Fratelli Barri" });

            migrationBuilder.InsertData(
                table: "Finishings",
                columns: new[] { "Id", "CollectionId", "Name" },
                values: new object[] { 1, 1, "Silver " });

            migrationBuilder.InsertData(
                table: "FurnitureNames",
                columns: new[] { "Id", "CollectionId", "Name" },
                values: new object[] { 1, 1, "Side Table" });

            migrationBuilder.InsertData(
                table: "FurnitureTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Стол" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandCollections");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Finishings");

            migrationBuilder.DropTable(
                name: "FurnitureNames");

            migrationBuilder.DropTable(
                name: "FurnitureTypes");

            migrationBuilder.DropTable(
                name: "ProductLists");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
