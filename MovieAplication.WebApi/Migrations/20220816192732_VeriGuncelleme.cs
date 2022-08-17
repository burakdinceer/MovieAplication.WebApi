using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAplication.WebApi.Migrations
{
    public partial class VeriGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SeialId",
                table: "Genres");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Serials",
                type: "decimal(12,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(12,1)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Movies",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)");

            migrationBuilder.AlterColumn<int>(
                name: "SerialId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "SerialId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Serials",
                type: "decimal(12,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,1)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(12,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,1)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Movies",
                type: "decimal(12,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");

            migrationBuilder.AlterColumn<int>(
                name: "SerialId",
                table: "Genres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SeialId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "SerialId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
