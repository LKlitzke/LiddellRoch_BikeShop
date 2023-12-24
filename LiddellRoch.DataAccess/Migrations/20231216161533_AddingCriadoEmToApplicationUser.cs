using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingCriadoEmToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 16, 13, 15, 33, 95, DateTimeKind.Local).AddTicks(1538));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 54, 12, 415, DateTimeKind.Local).AddTicks(8120));
        }
    }
}
