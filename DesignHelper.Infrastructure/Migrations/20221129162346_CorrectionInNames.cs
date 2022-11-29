using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignHelper.Infrastructure.Migrations
{
    public partial class CorrectionInNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectToolsUsed_ProjectsEntities_ProjectId",
                table: "ProjectToolsUsed");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectToolsUsed",
                newName: "ProjectsEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectToolsUsed_ProjectsEntities_ProjectsEntityId",
                table: "ProjectToolsUsed",
                column: "ProjectsEntityId",
                principalTable: "ProjectsEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectToolsUsed_ProjectsEntities_ProjectsEntityId",
                table: "ProjectToolsUsed");

            migrationBuilder.RenameColumn(
                name: "ProjectsEntityId",
                table: "ProjectToolsUsed",
                newName: "ProjectId");

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => new { x.ApplicationUserId, x.ProjectEntityId });
                    table.ForeignKey(
                        name: "FK_UserProject_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProject_ProjectsEntities_ProjectEntityId",
                        column: x => x.ProjectEntityId,
                        principalTable: "ProjectsEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectEntityId",
                table: "UserProject",
                column: "ProjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectToolsUsed_ProjectsEntities_ProjectId",
                table: "ProjectToolsUsed",
                column: "ProjectId",
                principalTable: "ProjectsEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
