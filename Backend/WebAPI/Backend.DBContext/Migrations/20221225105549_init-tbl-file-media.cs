using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DBContext.Migrations
{
    public partial class inittblfilemedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Media");

            migrationBuilder.CreateTable(
                name: "CategoryMedia",
                schema: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryMedia_CategoryMedia_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Media",
                        principalTable: "CategoryMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryMedia_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "App",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileCategory",
                schema: "Media",
                columns: table => new
                {
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCategory", x => new { x.CategoryId, x.FileId });
                    table.ForeignKey(
                        name: "FK_FileCategory_CategoryMedia_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Media",
                        principalTable: "CategoryMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileCategory_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "Media",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMedia_ParentId",
                schema: "Media",
                table: "CategoryMedia",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMedia_UserId",
                schema: "Media",
                table: "CategoryMedia",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileCategory_FileId",
                schema: "Media",
                table: "FileCategory",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileCategory",
                schema: "Media");

            migrationBuilder.DropTable(
                name: "CategoryMedia",
                schema: "Media");

            migrationBuilder.DropTable(
                name: "File",
                schema: "Media");
        }
    }
}
