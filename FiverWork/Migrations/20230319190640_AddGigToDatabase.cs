using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiverWork.Migrations
{
    /// <inheritdoc />
    public partial class AddGigToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gigs",
                columns: table => new
                {
                    GigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GigTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GigImage1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GigImage2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GigImage3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GigImage4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GigImage5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GigRating = table.Column<double>(type: "float", nullable: false),
                    GigRatingCount = table.Column<int>(type: "int", nullable: false),
                    GigPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gigs", x => x.GigId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gigs");
        }
    }
}
