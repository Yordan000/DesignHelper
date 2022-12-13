using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class AddingMappingTableForUsersAndProjectsNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
