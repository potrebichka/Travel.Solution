﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAPI.Models;

namespace TravelAPI.Migrations
{
    [DbContext(typeof(TravelAPIContext))]
    [Migration("20200128231214_Seventh")]
    partial class Seventh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelAPI.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<double>("Rating");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");

                    b.HasData(
                        new
                        {
                            DestinationId = 1,
                            City = "Seattle",
                            Country = "USA",
                            Rating = 4.5
                        },
                        new
                        {
                            DestinationId = 2,
                            City = "Vancouver",
                            Country = "Canada",
                            Rating = 5.0
                        },
                        new
                        {
                            DestinationId = 3,
                            City = "Bangkok",
                            Country = "Thailand",
                            Rating = 0.0
                        },
                        new
                        {
                            DestinationId = 4,
                            City = "Moscow",
                            Country = "Russia",
                            Rating = 0.0
                        },
                        new
                        {
                            DestinationId = 5,
                            City = "Paris",
                            Country = "France",
                            Rating = 0.0
                        },
                        new
                        {
                            DestinationId = 6,
                            City = "Tokio",
                            Country = "Japan",
                            Rating = 4.0
                        },
                        new
                        {
                            DestinationId = 7,
                            City = "Melbourne",
                            Country = "Australia",
                            Rating = 2.5
                        },
                        new
                        {
                            DestinationId = 8,
                            City = "Bejing",
                            Country = "China",
                            Rating = 0.0
                        },
                        new
                        {
                            DestinationId = 9,
                            City = "Athens",
                            Country = "Greece",
                            Rating = 5.0
                        },
                        new
                        {
                            DestinationId = 10,
                            City = "Los Angeles",
                            Country = "USA",
                            Rating = 0.0
                        });
                });

            modelBuilder.Entity("TravelAPI.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DestinationId");

                    b.Property<double>("Rating");

                    b.Property<string>("user_name");

                    b.HasKey("ReviewId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Description = "Great city with many things to check out for everyone! One can find a great balance between city life and nature without driving too far. No matter where you are, you will always see evergreen trees and mountains. Along with many lakes and top notch sea food.",
                            DestinationId = 1,
                            Rating = 4.0,
                            user_name = "user1"
                        },
                        new
                        {
                            ReviewId = 2,
                            Description = "I love this city. Super expensive to live in, but still great. I could not imagine living anywhere else in the world.",
                            DestinationId = 1,
                            Rating = 5.0,
                            user_name = "user1"
                        },
                        new
                        {
                            ReviewId = 3,
                            Description = "Such a beautiful city with easy access to the ocean, gorgeous hiking trails, places to ski, and so much more. Lots of art, culture, and good food. So much to do and explore within the city. Also easy access to locations like the San Juan Islands and Leavenworth. I have lived here all my life and still have so much to explore.",
                            DestinationId = 1,
                            Rating = 4.5,
                            user_name = "user2"
                        },
                        new
                        {
                            ReviewId = 4,
                            Description = "Vancouver, Canada is a beautiful city. We were there in August and the weather was great. Two sights that are a 'must see' are Standley Park and the Capilano Suspension Bridge. A drive along the coastline provides great views.",
                            DestinationId = 2,
                            Rating = 5.0,
                            user_name = "user1"
                        },
                        new
                        {
                            ReviewId = 5,
                            Description = "I love Japan. Food = Super-duper #1, People = Friendly, City = Safe/Clean, Sites = Cool, Not that far away, What else? Oh yeah...THE FOOD!",
                            DestinationId = 6,
                            Rating = 5.0,
                            user_name = "user2"
                        },
                        new
                        {
                            ReviewId = 6,
                            Description = "my Husband and I spent 8 days on vacation in Tokyo, March 28 -April 5th 2010. We had a great time, we went all over the city, we found it clean and safe and the people very helpful. I read they appear to take great pride in their jobs and I would agree with that. Theres a lot of bowing and nodding, very polite people we found. The weather was generally very cold, I had to buy some gloves but we did have alot of sunny days and the cherry blossom was in perfect full bloom all over the city.",
                            DestinationId = 6,
                            Rating = 3.0,
                            user_name = "user3"
                        },
                        new
                        {
                            ReviewId = 7,
                            Description = "It is a living breathing, sleepless city; it is no wonder western civilisation began there. It is the only place where the taxi drivers are the best psychologists, or the most maniacal of the insane. The men and women are stunning, it is a place which is constantly moving but at a human pace; it is all based around living life, not moving up a career ladder. The nightlife is amazing as is the day life.",
                            DestinationId = 9,
                            Rating = 5.0,
                            user_name = "user5"
                        },
                        new
                        {
                            ReviewId = 8,
                            Description = "Some review basjdhfkjasfhjk ...",
                            DestinationId = 7,
                            Rating = 3.0,
                            user_name = "user1"
                        },
                        new
                        {
                            ReviewId = 9,
                            Description = "Some another review jkshfjkhasjf",
                            DestinationId = 7,
                            Rating = 2.0,
                            user_name = "user4"
                        },
                        new
                        {
                            ReviewId = 10,
                            Description = "REviEWWWWWWWWWWWWWW",
                            DestinationId = 10,
                            Rating = 0.0,
                            user_name = "user6"
                        });
                });

            modelBuilder.Entity("TravelAPI.Models.Review", b =>
                {
                    b.HasOne("TravelAPI.Models.Destination", "Destination")
                        .WithMany("Reviews")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
