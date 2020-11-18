using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.EFCore.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepoOwners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    AvatarUrl = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepoOwners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Repos",
                columns: table => new
                {
                    RepoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Language = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ForksCount = table.Column<int>(nullable: false),
                    StargazersCount = table.Column<int>(nullable: false),
                    HtmlUrl = table.Column<string>(maxLength: 2000, nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    Uuid = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repos", x => x.RepoId);
                    table.ForeignKey(
                        name: "FK_Repos_RepoOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "RepoOwners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repos_OwnerId",
                table: "Repos",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repos");

            migrationBuilder.DropTable(
                name: "RepoOwners");
        }
    }
}
