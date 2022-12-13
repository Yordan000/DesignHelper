using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class AddingAditionalPropertyForProjectEntityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "ProjectsEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7618ad34-7988-4b8e-bbc3-3eec235630ae", "AQAAAAEAACcQAAAAEKO8uwFpmPy1mg0PWN32EYfUx9RT1c3EU7LUXrDNGgPIU6aIiuj6a+AqRC17Pc2w0Q==", "e0a5a3fe-465e-45c7-9687-777f2aa43c96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "851da6be-49f9-4681-a11b-31b2a9fcf4cb", "AQAAAAEAACcQAAAAEJPNKuHJZpBvSpip/Ybj5j0JHT2Slgm+z20SER7QdRiVzXA795+88rEPLqMsa3J2rQ==", "967532af-006a-41c3-a06b-c463e877cc33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "628a81cf-55f9-4b19-9b27-dec683d08d45", "AQAAAAEAACcQAAAAEG1LA7KCsuP5bhxbz0Zmdmt5UAfeKBxLPtudK3ybTr6qkD71Srf4CH37u13kQEcDnw==", "12a36f63-cf5a-47bd-a850-ccf344cf780c" });

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedById",
                value: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedById",
                value: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedById",
                value: "5faa7c98-430f-4036-928f-f5210e8fbeea");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedById",
                value: "5faa7c98-430f-4036-928f-f5210e8fbeea");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedById",
                value: "5faa7c98-430f-4036-928f-f5210e8fbeea");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedById",
                value: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedById",
                value: "5faa7c98-430f-4036-928f-f5210e8fbeea");

            migrationBuilder.UpdateData(
                table: "ProjectsEntities",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedById",
                value: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "ProjectsEntities");

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
        }
    }
}
