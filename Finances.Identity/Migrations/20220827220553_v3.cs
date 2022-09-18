using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finances.Identity.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    NameDebts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryEvenues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameTransfer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourTransfer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryEvenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryEvenues_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUpload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal = table.Column<double>(type: "float", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Remembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRemember = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remembers_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revenue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastEarns = table.Column<double>(type: "float", nullable: false),
                    CurrentEarns = table.Column<double>(type: "float", nullable: false),
                    DayEarn = table.Column<double>(type: "float", nullable: false),
                    CurrenteRevenue = table.Column<double>(type: "float", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revenue_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorsCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ValueGoal = table.Column<double>(type: "float", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorsCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorsCountries_MyUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debts_UsersId",
                table: "Debts",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEvenues_UsersId",
                table: "HistoryEvenues",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UsersId",
                table: "Projects",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Remembers_UsersId",
                table: "Remembers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_UsersId",
                table: "Revenue",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UsersId",
                table: "ToDos",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorsCountries_UsersId",
                table: "VisitorsCountries",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "HistoryEvenues");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Remembers");

            migrationBuilder.DropTable(
                name: "Revenue");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "VisitorsCountries");
        }
    }
}
