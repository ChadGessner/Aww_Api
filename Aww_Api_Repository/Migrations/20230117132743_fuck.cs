using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwwApiRepository.Migrations
{
    /// <inheritdoc />
    public partial class fuck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AwwImages",
                columns: table => new
                {
                    AwwId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AwwCategoryDTCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwwImages", x => x.AwwId);
                    table.ForeignKey(
                        name: "FK_AwwImages_Categories_AwwCategoryDTCategoryId",
                        column: x => x.AwwCategoryDTCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwwImages_AwwCategoryDTCategoryId",
                table: "AwwImages",
                column: "AwwCategoryDTCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwwImages");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
