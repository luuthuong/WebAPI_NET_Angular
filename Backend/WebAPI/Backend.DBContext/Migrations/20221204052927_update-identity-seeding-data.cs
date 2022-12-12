using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DBContext.Migrations
{
    public partial class updateidentityseedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeedDataHistory",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedDataHistory", x => x.Id);
                });  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeedDataHistory",
                schema: "App");
        }
    }
}
