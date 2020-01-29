using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationReviews");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "DestinationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "DestinationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "DestinationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4,
                column: "DestinationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 5,
                column: "DestinationId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 6,
                column: "DestinationId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 7,
                column: "DestinationId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 8,
                column: "DestinationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 9,
                column: "DestinationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 10,
                column: "DestinationId",
                value: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Destinations_DestinationId",
                table: "Reviews",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Destinations_DestinationId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "DestinationReviews",
                columns: table => new
                {
                    DestinationReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DestinationId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationReviews", x => x.DestinationReviewId);
                    table.ForeignKey(
                        name: "FK_DestinationReviews_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DestinationReviews",
                columns: new[] { "DestinationReviewId", "DestinationId", "ReviewId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 6, 5 },
                    { 6, 6, 6 },
                    { 7, 9, 7 },
                    { 8, 7, 8 },
                    { 9, 7, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationReviews_DestinationId",
                table: "DestinationReviews",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationReviews_ReviewId",
                table: "DestinationReviews",
                column: "ReviewId",
                unique: true);
        }
    }
}
