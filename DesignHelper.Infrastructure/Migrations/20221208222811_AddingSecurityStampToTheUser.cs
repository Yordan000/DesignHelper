using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class AddingSecurityStampToTheUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c94051d2-ae95-44b5-8be2-4bae34305fd8", "AQAAAAEAACcQAAAAEEyfOjHvhovUmHGIbFfOxnSJkJhrGBE2vwpo8C/IGyDl+zeB0lWZ7JOYI8qDEmuQ7Q==", "7f4d7468-94a4-4537-9299-c576001706c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e159a5fb-0de4-4b12-afb3-dda219cf8c04", "AQAAAAEAACcQAAAAEJ7QxL4s9nF+4TjqV0r29GZLIb4UJr/+QEXRNmtJjeX6z6JcxJsuiW0fMlYpPbnwZw==", "699845f8-b39c-4fff-a214-2a0a66104561" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e0c8fcf-3fef-4d29-91d6-3b0455cf8b8f", "AQAAAAEAACcQAAAAEFC1XhN5EtkbO87u2j4jvQkYwoN8aYveEPK2Vn7p8vhMZNWub+f5o9qSyxPiUsTovA==", "c9f803a9-189e-44ac-9090-6a1c274e7496" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b582c5dc-75e0-482d-89ff-57cb9101d0a9", "AQAAAAEAACcQAAAAEDg7bTAauQF66WtEk1fNNlP6uacX0esM7LZvIykIwxaQJcWRrgeUkfTBuxOCeLZlNQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5faa7c98-430f-4036-928f-f5210e8fbeea",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6acca0e5-2b85-43f1-adc4-d9971677b32f", "AQAAAAEAACcQAAAAEEd4j0JNUzIgD4rE/m/0O/b61SGPndbEoo89C7mJksdrgtXOymIHAFHvjk7CHC+uUQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7312257-f632-4bd3-809f-7b0453bf7b3b", "AQAAAAEAACcQAAAAEMK3BNJMtlc2Wi6d4o/OB3udjcDg0LHpdAVgCSlspssiSgYpHq43/AWF2yORBAA5EA==", null });
        }
    }
}
