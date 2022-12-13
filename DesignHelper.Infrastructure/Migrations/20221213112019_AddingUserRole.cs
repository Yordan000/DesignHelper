using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class AddingUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "379c2300-ef17-4b98-8b01-e7d86b181c35", "AQAAAAEAACcQAAAAENO7xLsOrHA9Iz/PKWYmQAYnJSXHNDtwQ696QqhI2InNSLQmNmab1C8VSarvzBld/g==", "0b387d08-9bad-4937-a5e7-40be1eff4330" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4db94484-8ef6-4fb5-b3c1-773b5ac6c45b", "AQAAAAEAACcQAAAAEF/+YXhv3WB3tUd+zxkOgyNV3h+hs1WxqHzPtG9zeriNWl4XHndVc0ncl1OkAIvzWQ==", "8e9c8c72-f09a-4fde-b564-5588c58f0fd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3ed97b6-6bac-4619-910e-758c25ae4dae", "AQAAAAEAACcQAAAAEBOl6axrNoGySOlLGvLV01xes0hQ531jnjD6FnQLkqhsyilPi12hTLx/WDF6zsBNxg==", "ccf2e330-f119-48cb-8b5e-6315a58757f0" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserRoleId",
                table: "AspNetUsers",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_UserRoleId",
                table: "AspNetUsers",
                column: "UserRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_UserRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f9f832-23e3-4e52-9ad2-ca1a3e4bb1ef", "AQAAAAEAACcQAAAAEHNX/JM34zxWkbQiAVXJo9anMLsnPJa6TyGykK9hdamJHX/9vfkEccT6cp4aRfZv3w==", "47968690-6c08-4483-9f84-e278a8981fbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef554900-303f-4fa7-ae41-cd018022b31c", "AQAAAAEAACcQAAAAECwuxTGjoBWBJxGrIJ3qtM6dOLdYolFoCaWhPJL4GoSDRj06kYmp1nVio7pB2zVAhA==", "dec94dff-0d93-447f-9fe4-922cb758aa9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6d83be6-a45f-4861-bce9-cd7fe8d55455", "AQAAAAEAACcQAAAAEKcfuURWVb1SfAE+A3J7ufRDixRw0uGBGzrtI6ll8cbO1QUho+osXYJjeTdrnSQ2Sg==", "8ca8023f-0abe-438e-8036-326e8238ab98" });
        }
    }
}
