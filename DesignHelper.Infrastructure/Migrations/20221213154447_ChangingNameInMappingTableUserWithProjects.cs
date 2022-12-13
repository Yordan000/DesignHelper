using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class ChangingNameInMappingTableUserWithProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWithProjects_ProjectsEntities_ProjectsEntityId",
                table: "UserWithProjects");

            migrationBuilder.RenameColumn(
                name: "ProjectsEntityId",
                table: "UserWithProjects",
                newName: "ProjectId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserWithProjects_ProjectsEntities_ProjectId",
                table: "UserWithProjects",
                column: "ProjectId",
                principalTable: "ProjectsEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWithProjects_ProjectsEntities_ProjectId",
                table: "UserWithProjects");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "UserWithProjects",
                newName: "ProjectsEntityId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92f4ad44-a603-4e12-bc8f-5a6a8cc4a91b", "AQAAAAEAACcQAAAAEAAan9wYzSVPc31Pw61kqOPYx1qxEuRu2NEnLZ+NZOBpt7SEd+JSkdHSW+E+rzoMpQ==", "7712c31a-a398-4151-a919-0a17048b9cf0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f2fa4d3-4646-4b13-a425-abb3293fd967", "AQAAAAEAACcQAAAAEGrKrTj4PlDRdO+7cS4Zmet5Unvaxjd7q7YObigTKrOqN/LTeIGl+n4EQ9PsEAWorA==", "7a359f5b-aa78-4906-b261-06fdbc9b9b4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd09645f-356f-4424-9b02-8ab06b2ac28b", "AQAAAAEAACcQAAAAEP338CSUu2+zAkzYTa+VlGaojzIeAHPjbVJamX8jK6sA2THGrug1XklJ+lDGRSQGQA==", "4da03bce-f73b-4fd1-9c50-6ed85a824eb2" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserWithProjects_ProjectsEntities_ProjectsEntityId",
                table: "UserWithProjects",
                column: "ProjectsEntityId",
                principalTable: "ProjectsEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
