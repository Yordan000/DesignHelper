using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class RemovingIsFavouritePropertyFromProjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEntities_AspNetUsers_AddToFavouritesId",
                table: "ProjectsEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsEntities_AddToFavouritesId",
                table: "ProjectsEntities");

            migrationBuilder.DropColumn(
                name: "AddToFavouritesId",
                table: "ProjectsEntities");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddToFavouritesId",
                table: "ProjectsEntities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74b704a6-f9e5-4f28-9800-4018d1ea3cf5", "AQAAAAEAACcQAAAAEBtqYwetn2ZQ6kBNHNQZaLbsXUJfYqKGS1WvdqWSsiVdFTYkPvVfoInNfmOLH1oRSg==", "c5f88111-280c-4f86-afc9-64c5a45bc201" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23163872-6866-4a0a-83d5-031680681ee4", "AQAAAAEAACcQAAAAEElKhwsR38lHG/6nyS7nGuy8isdoQtzjrRG4lAtbJbRulXU9bLyVHhvQQO5ms7RIUQ==", "bf15f5c2-7530-49c2-a612-d9628f8eb0f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e96f1833-61fb-4f40-82cf-5812bae51ce7", "AQAAAAEAACcQAAAAEIgoL/+ONvPApXH3oc6uoC96oA0EHPjoOWLfQnPcI0GIvt7kR0vJKr5t26JvUjfspQ==", "2afb6618-0282-4428-83dc-59445284aa2d" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEntities_AddToFavouritesId",
                table: "ProjectsEntities",
                column: "AddToFavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEntities_AspNetUsers_AddToFavouritesId",
                table: "ProjectsEntities",
                column: "AddToFavouritesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
