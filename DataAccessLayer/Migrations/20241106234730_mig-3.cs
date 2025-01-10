using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalismaSaati",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cinsiyet",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeTarihi",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IlanKategori",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Konum",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Tarih",
                table: "Ilanlar",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalismaSaati",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "EklemeTarihi",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "IlanKategori",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "Konum",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "Ilanlar");
        }
    }
}
