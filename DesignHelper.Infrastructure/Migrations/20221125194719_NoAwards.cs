using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class NoAwards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "No awards" });
        }
    }
}
