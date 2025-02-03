using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otaghche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "HotelId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "وای فای" },
                    { 2, null, 1, "صبحانه" },
                    { 3, null, 1, "تلویزیون" },
                    { 4, null, 1, "یخچال" },
                    { 5, null, 2, "رستوران" },
                    { 6, null, 2, "تاکسی سرویس" },
                    { 7, null, 2, "صندوق امانات" },
                    { 8, null, 2, "سرویس فرنگی" },
                    { 9, null, 3, "کافی شاپ" },
                    { 10, null, 3, "سالن اجتماعات" },
                    { 11, null, 3, "فروشگاه و خرید" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_HotelId",
                table: "Amenities",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");
        }
    }
}
