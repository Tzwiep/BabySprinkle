using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetDiapers.Data.Migrations
{
    public partial class CorrectionsToPreviousMigrationErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyPredictions_Guests_GuestId1",
                table: "BabyPredictions");

            migrationBuilder.DropIndex(
                name: "IX_BabyPredictions_GuestId1",
                table: "BabyPredictions");

            migrationBuilder.DropColumn(
                name: "GuestId1",
                table: "BabyPredictions");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "BabyPredictions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BabyPredictions_GuestId",
                table: "BabyPredictions",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BabyPredictions_Guests_GuestId",
                table: "BabyPredictions",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BabyPredictions_Guests_GuestId",
                table: "BabyPredictions");

            migrationBuilder.DropIndex(
                name: "IX_BabyPredictions_GuestId",
                table: "BabyPredictions");

            migrationBuilder.AlterColumn<string>(
                name: "GuestId",
                table: "BabyPredictions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GuestId1",
                table: "BabyPredictions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BabyPredictions_GuestId1",
                table: "BabyPredictions",
                column: "GuestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BabyPredictions_Guests_GuestId1",
                table: "BabyPredictions",
                column: "GuestId1",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
