using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class AddingMappingTableForUsersAndProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserWithProjects",
                columns: table => new
                {
                    ProjectsEntityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWithProjects", x => new { x.ProjectsEntityId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserWithProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWithProjects_ProjectsEntities_ProjectsEntityId",
                        column: x => x.ProjectsEntityId,
                        principalTable: "ProjectsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89c11b1c-5922-4f63-853a-92c17eeb36f9", "AQAAAAEAACcQAAAAEM/5oj5bkBCPps15a/gEIyVa/s3MxwrlrOPGqZ+ejTUypaPh/BJTp8Fi14cRRiTqDw==", "7d181f8e-aa53-4fbb-9e50-2ab5f0b2c6ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd4fda0a-a665-4dc7-9a6e-815f2bad69c1", "AQAAAAEAACcQAAAAEHe5QDr2weTReGgCBzucsfEj75ue96xpVVmV8clNQXWkupHV27hO0iP+NdxlCCYqMg==", "a089ff13-ddc9-4e3e-a099-90bc5d8f42fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b40d362c-e78f-4602-bad5-79da80d34b75", "AQAAAAEAACcQAAAAEKoNiqkIvLu9NqHOswYdaV/0w6IXpslWRWi+6tAoLUI7k/VE5kZdktSs6lJIcjS/DQ==", "6806ec9b-80aa-410a-90b9-fa70cff960a3" });

            migrationBuilder.CreateIndex(
                name: "IX_UserWithProjects_UserId",
                table: "UserWithProjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWithProjects");

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
    }
}
