using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetDiapers.Data.Migrations
{
    public partial class CreateGuestandBabyPredictor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BabyPredictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Due_Date = table.Column<DateTime>(nullable: false),
                    Birth_Weight = table.Column<double>(nullable: false),
                    Baby_Name = table.Column<string>(nullable: true),
                    GuestId = table.Column<string>(nullable: true),
                    GuestId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyPredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyPredictions_Guests_GuestId1",
                        column: x => x.GuestId1,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BabyPredictions_GuestId1",
                table: "BabyPredictions",
                column: "GuestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UserId",
                table: "Guests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BabyPredictions");

            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
