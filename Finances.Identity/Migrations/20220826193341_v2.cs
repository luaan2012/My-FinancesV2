using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finances.Identity.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FirtsLogin",
                table: "MyUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiveSalary",
                table: "MyUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirtsLogin",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "ReceiveSalary",
                table: "MyUser");
        }
    }
}
