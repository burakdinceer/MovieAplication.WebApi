using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAplication.WebApi.Migrations
{
    public partial class VeriYenileme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SerialId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SerialId",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Serials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Serials_GenreId",
                table: "Serials",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Serials_Genres_GenreId",
                table: "Serials",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Serials_Genres_GenreId",
                table: "Serials");

            migrationBuilder.DropIndex(
                name: "IX_Serials_GenreId",
                table: "Serials");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Serials");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerialId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieId",
                table: "Genres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SerialId",
                table: "Genres",
                column: "SerialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MovieId",
                table: "Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "SerialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
