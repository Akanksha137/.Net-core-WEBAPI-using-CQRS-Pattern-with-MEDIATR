using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_Demo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    MainCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "MainCategory" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Berry", "Griffin Beak Eldritch", "Ships" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Nancy", "Swashbuckler Rye", "Rum" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTimeOffset(new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Eli", "Ivory Bones Sweet", "Singing" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new DateTimeOffset(new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Arnold", "The Unseen Stafford", "Singing" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Seabury", "Toxic Reyson", "Maps" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), new DateTimeOffset(new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Rutherford", "Fearless Cloven", "General debauchery" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), new DateTimeOffset(new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Atherton", "Crow Ridley", "Rum" },
                    { new Guid("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"), new DateTimeOffset(new DateTime(1969, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Huxford", "The Hawk Morris", "Maps" },
                    { new Guid("119f9ccb-149d-4d3c-ad4f-40100f38e918"), new DateTimeOffset(new DateTime(1972, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Dwennon", "Rigger Quye", "Maps" },
                    { new Guid("28c1db41-f104-46e6-8943-d31c0291e0e3"), new DateTimeOffset(new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Rushford", "Subtle Asema", "Rum" },
                    { new Guid("d94a64c2-2e8f-4162-9976-0ffe03d30767"), new DateTimeOffset(new DateTime(1976, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Hagley", "Imposter Grendel", "Singing" },
                    { new Guid("380c2c6b-0d1c-4b82-9d83-3cf635a3e62b"), new DateTimeOffset(new DateTime(1977, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), "Mabel", "Barnacle Grendel", "Maps" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
