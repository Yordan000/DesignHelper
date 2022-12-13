using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class ChangesInMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWithProjects");

            migrationBuilder.CreateTable(
                name: "UsersProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProjects", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProjects_ProjectsEntities_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "321f7fc6-d5cd-413e-a333-e78a0e4c0361", "AQAAAAEAACcQAAAAEFRupaqpe/20hY6BLZMJr5ReBg2N8TlmcedCA+vfVXGACdzdqUvpu1jJ0omEScTkFA==", "ba242dd1-3f4a-441e-9d18-25cb2897f83f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9ee9f67-a18a-40c4-96ab-c9d9f5912c62", "AQAAAAEAACcQAAAAEOLEUHG6Dng2ITcZHRqzZqmTNuR/FvNqTjaIZO16fYBrOas9KQWv4pcJUtVVFxLWLw==", "90a3ed49-ecea-4a1b-b591-f295b36c78ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb418f8b-3d8e-424b-9e68-0f2f2d1ebb9c", "AQAAAAEAACcQAAAAEG7pLXY0u+31R8e2+YiQu/S1GGKdbiLSoaq/KG6p+6lhdPgijCIwuOCnkvpCtOqcdA==", "899fbfec-555e-4d4d-9ad5-60af822c2ef4" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersProjects_UserId",
                table: "UsersProjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersProjects");

            migrationBuilder.CreateTable(
                name: "UserWithProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWithProjects", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserWithProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWithProjects_ProjectsEntities_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d06c2d33-5b06-445f-bded-168865501593", "AQAAAAEAACcQAAAAEPPykBbeTJhNac1GdZAdOcaaivR707jbd/IavI6Wr3+s5tQ4SYYew2p049wo0ld6aQ==", "9d5de155-ccdd-4fdf-977a-11aa55ee2fb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "100f57e2-1034-476d-8894-1a29448d39e4", "AQAAAAEAACcQAAAAEPT2ycP7atG3eUraczd5UAW13Lel6pT2uXq7Jd7abf+R/i02h6joL1/Sw5fb8eXuqA==", "e00e3471-8958-4b9d-b591-4ef1ed6318bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ab0003e-219a-4c87-9c49-3c6d37df455f", "AQAAAAEAACcQAAAAENqB22jML7FLI/AXdjuFoqhPy94bTxixOELx/T/S4rlkQJQx0yv93LiRlT8fCGdKqw==", "2e630b3a-df2f-4d8d-b5ab-80df71e72105" });

            migrationBuilder.CreateIndex(
                name: "IX_UserWithProjects_UserId",
                table: "UserWithProjects",
                column: "UserId");
        }
    }
}
