using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DBContext.Migrations
{
    public partial class addcolumnkeyrefreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                schema: "App",
                table: "RefreshToken");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "App",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "App",
                table: "RefreshToken",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                schema: "App",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                schema: "App",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                schema: "App",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_UserId",
                schema: "App",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "App",
                table: "RefreshToken");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "App",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                schema: "App",
                table: "RefreshToken",
                column: "UserId");
        }
    }
}
