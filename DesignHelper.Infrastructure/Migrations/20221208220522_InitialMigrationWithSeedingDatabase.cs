using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class InitialMigrationWithSeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolsUsed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolsUsed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopRatedEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopRatedEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AwardId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddToFavouritesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TopRatedEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsEntities_AspNetUsers_AddToFavouritesId",
                        column: x => x.AddToFavouritesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectsEntities_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsEntities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsEntities_TopRatedEntities_TopRatedEntityId",
                        column: x => x.TopRatedEntityId,
                        principalTable: "TopRatedEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectToolsUsed",
                columns: table => new
                {
                    ProjectsEntityId = table.Column<int>(type: "int", nullable: false),
                    ToolsUsedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectToolsUsed", x => new { x.ProjectsEntityId, x.ToolsUsedId });
                    table.ForeignKey(
                        name: "FK_ProjectToolsUsed_ProjectsEntities_ProjectsEntityId",
                        column: x => x.ProjectsEntityId,
                        principalTable: "ProjectsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectToolsUsed_ToolsUsed_ToolsUsedId",
                        column: x => x.ToolsUsedId,
                        principalTable: "ToolsUsed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3c128b69-c44c-4c7d-9f7a-9921c86bbf29", 0, "b582c5dc-75e0-482d-89ff-57cb9101d0a9", "user@gmail.com", false, "Yordan", true, "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEDg7bTAauQF66WtEk1fNNlP6uacX0esM7LZvIykIwxaQJcWRrgeUkfTBuxOCeLZlNQ==", null, false, null, false, "user@gmail.com" },
                    { "5faa7c98-430f-4036-928f-f5210e8fbeea", 0, "6acca0e5-2b85-43f1-adc4-d9971677b32f", "guest@gmail.com", false, "Yordan", true, "Guest", false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAEAACcQAAAAEEd4j0JNUzIgD4rE/m/0O/b61SGPndbEoo89C7mJksdrgtXOymIHAFHvjk7CHC+uUQ==", null, false, null, false, "guest@gmail.com" },
                    { "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07", 0, "b7312257-f632-4bd3-809f-7b0453bf7b3b", "admin@gmail.com", false, "Yordan", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMK3BNJMtlc2Wi6d4o/OB3udjcDg0LHpdAVgCSlspssiSgYpHq43/AWF2yORBAA5EA==", null, false, null, false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Best Architecture Award 2022" },
                    { 2, "Best Interior Design Award 2022" },
                    { 3, "Best Visualization Award 2022" },
                    { 4, "Best Photography Award 2022" },
                    { 5, "No awards" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Architecture" },
                    { 2, "Interior Design" },
                    { 3, "Visualization" },
                    { 4, "Photography" }
                });

            migrationBuilder.InsertData(
                table: "ToolsUsed",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "3Ds Max" },
                    { 2, "AutoCAD" },
                    { 3, "Revit" },
                    { 4, "Archicad" },
                    { 5, "Lumion" },
                    { 6, "Photoshop" },
                    { 7, "Vray" },
                    { 8, "Corona" },
                    { 9, "Canon 6D" },
                    { 10, "Sony Alpha 7Riii" },
                    { 11, "Nikon" }
                });

            migrationBuilder.InsertData(
                table: "ProjectsEntities",
                columns: new[] { "Id", "AddToFavouritesId", "Area", "Author", "AwardId", "CategoryId", "Description", "ImageUrl", "IsActive", "Location", "Rating", "Title", "TopRatedEntityId" },
                values: new object[,]
                {
                    { 1, null, 5900.0, "LUKSTUDIO", 2, 2, "Cultivating elegance in the everyday. Located in the North Bund of Hongkou District, Hall of the Sun is a 180,000 square meter commercial hub with an emphasis of nature in the design, including its curvilinear facade and a 3-storey-high biophilic food hall under Shanghai’s largest skylight roof canopy. Informed by the organic architecture, Lukstudio has extended the concept of nature and vitality into the public interior spaces.", "https://amazingarchitecture.com/storage/3335/responsive-images/1-refining_the_ordinary_lukstudio_shanghai___media_library_original_1343_755.jpg", true, "No. 181 Rui Hong Road, Hong Kou District, Shanghai, China", 7.9m, "Refining the Ordinary", null },
                    { 2, null, 2360.0, "Colega Architects", 5, 1, "This full gut remodel was realized for a design minded couple moving from New York back to LA. Making the transition back to sunny California, the couple had visions of keeping doors and windows open year-round. Self-proclaimed foodies, they were looking forward to weekend gatherings and being able to entertain inside and out. They purchased a home that had the square footage and lot size they wanted but lacked the aesthetics, flow and functions they sought. Modern, warm and uncluttered was their vision. Without adding a square foot, the existing house was transformed from a “drive by - don’t notice you” tired, tract home, into a custom, “that’s a remodel?” modern home that fully encompassed the warmth of family life with the modern aesthetic the couple was looking for.", "https://amazingarchitecture.com/storage/3427/responsive-images/crestridge_residence_colega_architects_california___media_library_original_1344_756.jpg", true, "Rancho Palos Verdes, California, USA", 9.1m, "Crestridge Residence", null },
                    { 3, null, 6230.0, "AshariArchitects", 3, 3, "The development of Kish in terms of tourism has led to the construction of new urban texture and buildings in the city to attract tourists and it can be noted that hotels are a potential platform that attracts tourists in the city texture according to their architectural-environmental factors.", "https://amazingarchitecture.com/storage/3369/responsive-images/1-armitaj_hotel_kish_island_ashariarchitects___media_library_original_1344_756.jpg", true, "Kish Island, Iran", 8.3m, "Armitaj Hotel", null },
                    { 4, null, 385.0, "Maria Eirini Moschona", 5, 4, "Villa Lavante is a luxury holiday home whose construction was completed in July 2019. It is located within a complex consisting of two adjoining and fully equipped and furnished luxury villas (Villa Lavante with an independent guest house and Villa Rosmarina). Each has its own large pool. The two villas are separated by a long stone fence.", "https://amazingarchitecture.com/storage/2288/responsive-images/villa_lavante_antiparos_greece_maria_eirini_moschona-___media_library_original_1344_756.jpg", true, "Antiparos, Greece", 7.9m, "Villa Lavante", null },
                    { 5, null, 9800.0, "Waechter Architecture", 1, 1, "The Furioso Vineyards project consists of the renovation and expansion of an existing winery, including the addition of a new tasting room and public amenity spaces. The original Furioso estate, located in the heart of Oregon’s wine country, was made up of a series of disconnected utilitarian structures scattered across its property, including a steel-shed winery, various storage facilities, outdoor crush pad, and an adjacent residence. Built in disparate styles and materials, the estate lacked a cohesive identity. In addition, although completely surrounded by vineyards, the buildings turned their backs on the landscape, instead focusing on internal production.", "https://amazingarchitecture.com/storage/3278/responsive-images/1-furioso_vineyards_waechter_architecture_dundee___media_library_original_1344_756.jpg", true, "Dundee, Oregon, USA", 9.4m, "Furioso Vineyards", null },
                    { 6, null, 120.0, "Minus Workshop", 5, 2, "“Zen Oasis” - A home gateway infused with Japanese aesthetics designed by Minus Workshop. The founder of Minus Workshop, Kevin Yiu has long been inspired by Eastern philosophies. He has taken over this residential design project into a modified version of the spirit of zen in Japan for a family who loves Japanese culture and wants a respite from the hustle and bustle of city life. With the simple three worded design brief “Japanese, zen and calm” to request Kevin to design his 120 square metre apartment. As a result, Yiu also breaks through the paradox between how we imagine stereotypical Japanese minimalism.", "https://amazingarchitecture.com/storage/2613/responsive-images/zen_oasis_minus_workshop_hong_kong___media_library_original_1344_756.jpg", true, "The Pavilion Bay, New Territories, Hong Kong", 5.9m, "Zen Oasis", null },
                    { 7, null, 119608.0, "Aedas", 5, 3, "Wenzhou is planned to be one of the global high-tech cities by establishing Wenzhou Innovaland. The start-up zone integrates technology, financial, wellness and education, creating a mixed-use innovative hub in Wenzhou. Aedas Executive Director Yaochun Wen and Global Design Principal Dr. Andy Wen have jointly led the team to create a pioneering space in the zone.", "https://amazingarchitecture.com/storage/3212/responsive-images/wenzhou_innovaland_start_up_zone_aedas___media_library_original_1344_756.jpg", true, "Wenzhou, China", 8.9m, "Wenzhou Innovaland Start-Up Zone", null },
                    { 8, null, 289.0, "Vivien Renziehausen", 5, 4, "German hotel & architecture photographer Vivien Renziehausen portrayed the newly built company building of Plangrad Architects in Bremen, Germany. The building was designed and planned by the respective company itself. The concept of an open office whilst still having the privacy of your own office space has been greatly achieved through large glass fronts both on the outside and inside of the building. Symmetry and clear forms and structures dominate the interior and exterior design what made it technically challenging to photograph. Still, Vivien skillfully managed to capture and showcase the light and airy atmosphere within the straight architectural concept.", "https://amazingarchitecture.com/storage/3059/responsive-images/plangrad_architects_vivien_renziehausen_bremen_germany___media_library_original_1344_756.jpg", true, "Bremen, Germany", 6.8m, "Plangrad Architects", null }
                });

            migrationBuilder.InsertData(
                table: "ProjectToolsUsed",
                columns: new[] { "ProjectsEntityId", "ToolsUsedId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 8 },
                    { 3, 1 },
                    { 3, 4 },
                    { 3, 6 },
                    { 3, 8 },
                    { 4, 9 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 8 },
                    { 6, 2 },
                    { 6, 4 },
                    { 6, 6 },
                    { 6, 7 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 8 },
                    { 8, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEntities_AddToFavouritesId",
                table: "ProjectsEntities",
                column: "AddToFavouritesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEntities_AwardId",
                table: "ProjectsEntities",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEntities_CategoryId",
                table: "ProjectsEntities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEntities_TopRatedEntityId",
                table: "ProjectsEntities",
                column: "TopRatedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectToolsUsed_ToolsUsedId",
                table: "ProjectToolsUsed",
                column: "ToolsUsedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProjectToolsUsed");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ProjectsEntities");

            migrationBuilder.DropTable(
                name: "ToolsUsed");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TopRatedEntities");
        }
    }
}
