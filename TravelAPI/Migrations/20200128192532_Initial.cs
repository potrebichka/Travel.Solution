using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    user_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "City", "Country", "Rating" },
                values: new object[,]
                {
                    { 1, "Seattle", "USA", 4.5 },
                    { 2, "Vancouver", "Canada", 5.0 },
                    { 3, "Bangkok", "Thailand", 0.0 },
                    { 4, "Moscow", "Russia", 0.0 },
                    { 5, "Paris", "France", 0.0 },
                    { 6, "Tokio", "Japan", 4.0 },
                    { 7, "Melbourne", "Australia", 2.5 },
                    { 8, "Bejing", "China", 0.0 },
                    { 9, "Athens", "Greece", 5.0 },
                    { 10, "Los Angeles", "USA", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Description", "DestinationId", "Rating", "user_name" },
                values: new object[,]
                {
                    { 1, "Great city with many things to check out for everyone! One can find a great balance between city life and nature without driving too far. No matter where you are, you will always see evergreen trees and mountains. Along with many lakes and top notch sea food.", 1, 4.0, "user1" },
                    { 2, "I love this city. Super expensive to live in, but still great. I could not imagine living anywhere else in the world.", 1, 5.0, "user1" },
                    { 3, "Such a beautiful city with easy access to the ocean, gorgeous hiking trails, places to ski, and so much more. Lots of art, culture, and good food. So much to do and explore within the city. Also easy access to locations like the San Juan Islands and Leavenworth. I have lived here all my life and still have so much to explore.", 1, 4.5, "user_name2" },
                    { 4, "Vancouver, Canada is a beautiful city. We were there in August and the weather was great. Two sights that are a 'must see' are Standley Park and the Capilano Suspension Bridge. A drive along the coastline provides great views.", 2, 5.0, "user1" },
                    { 5, "I love Japan. Food = Super-duper #1, People = Friendly, City = Safe/Clean, Sites = Cool, Not that far away, What else? Oh yeah...THE FOOD!", 6, 5.0, "user2" },
                    { 6, "my Husband and I spent 8 days on vacation in Tokyo, March 28 -April 5th 2010. We had a great time, we went all over the city, we found it clean and safe and the people very helpful. I read they appear to take great pride in their jobs and I would agree with that. Theres a lot of bowing and nodding, very polite people we found. The weather was generally very cold, I had to buy some gloves but we did have alot of sunny days and the cherry blossom was in perfect full bloom all over the city.", 6, 3.0, "user3" },
                    { 8, "Some review basjdhfkjasfhjk ...", 7, 3.0, "user1" },
                    { 9, "Some another review jkshfjkhasjf", 7, 2.0, "user4" },
                    { 7, "It is a living breathing, sleepless city; it is no wonder western civilisation began there. It is the only place where the taxi drivers are the best psychologists, or the most maniacal of the insane. The men and women are stunning, it is a place which is constantly moving but at a human pace; it is all based around living life, not moving up a career ladder. The nightlife is amazing as is the day life.", 9, 5.0, "user5" },
                    { 10, "REviEWWWWWWWWWWWWWW", 10, 0.0, "user6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_DestinationId",
                table: "Review",
                column: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
