using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class FavouritesIdToProjectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddToFavouritesId",
                table: "ProjectsEntities",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
