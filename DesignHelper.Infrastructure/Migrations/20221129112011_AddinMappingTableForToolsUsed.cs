using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class AddinMappingTableForToolsUsed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ToolsId",
                table: "ProjectsEntities");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProjectsEntities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProjectToolsUsed",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ToolsUsedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectToolsUsed", x => new { x.ProjectId, x.ToolsUsedId });
                    table.ForeignKey(
                        name: "FK_ProjectToolsUsed_ProjectsEntities_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectToolsUsed_ToolsUsed_ToolsUsedId",
                        column: x => x.ToolsUsedId,
                        principalTable: "ToolsUsed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectToolsUsed_ToolsUsedId",
                table: "ProjectToolsUsed",
                column: "ToolsUsedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectToolsUsed");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProjectsEntities");

            migrationBuilder.AddColumn<int>(
                name: "ToolsId",
                table: "ToolsUsed",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToolsId",
                table: "ProjectsEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
