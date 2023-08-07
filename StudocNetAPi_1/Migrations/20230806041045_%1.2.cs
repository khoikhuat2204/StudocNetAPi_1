using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudocNetAPi_1.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Owners",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Pokemons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Owners");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Owners",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
