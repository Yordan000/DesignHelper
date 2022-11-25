using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class ChangingToolsUsedToList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsEntities_ToolsUsed_ToolsId",
                table: "ProjectsEntities");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsEntities_ToolsId",
                table: "ProjectsEntities");

            migrationBuilder.AddColumn<int>(
                name: "ToolsId",
                table: "ToolsUsed",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToolsUsed_ToolsId",
                table: "ToolsUsed",
                column: "ToolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToolsUsed_ProjectsEntities_ToolsId",
                table: "ToolsUsed",
                column: "ToolsId",
                principalTable: "ProjectsEntities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolsUsed_ProjectsEntities_ToolsId",
                table: "ToolsUsed");

            migrationBuilder.DropIndex(
                name: "IX_ToolsUsed_ToolsId",
                table: "ToolsUsed");

            migrationBuilder.DropColumn(
                name: "ToolsId",
                table: "ToolsUsed");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsEntities_ToolsId",
                table: "ProjectsEntities",
                column: "ToolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsEntities_ToolsUsed_ToolsId",
                table: "ProjectsEntities",
                column: "ToolsId",
                principalTable: "ToolsUsed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
