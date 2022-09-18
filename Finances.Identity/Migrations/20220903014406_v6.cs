using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finances.Identity.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenue_MyUser_UsersId",
                table: "Revenue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenue",
                table: "Revenue");

            migrationBuilder.RenameTable(
                name: "Revenue",
                newName: "Revenues");

            migrationBuilder.RenameIndex(
                name: "IX_Revenue_UsersId",
                table: "Revenues",
                newName: "IX_Revenues_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_MyUser_UsersId",
                table: "Revenues",
                column: "UsersId",
                principalTable: "MyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_MyUser_UsersId",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues");

            migrationBuilder.RenameTable(
                name: "Revenues",
                newName: "Revenue");

            migrationBuilder.RenameIndex(
                name: "IX_Revenues_UsersId",
                table: "Revenue",
                newName: "IX_Revenue_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenue",
                table: "Revenue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenue_MyUser_UsersId",
                table: "Revenue",
                column: "UsersId",
                principalTable: "MyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
