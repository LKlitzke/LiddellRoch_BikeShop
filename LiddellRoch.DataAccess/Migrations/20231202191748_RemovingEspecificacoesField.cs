using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovingEspecificacoesField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especificoes",
                table: "Bicicletas");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 16, 17, 48, 164, DateTimeKind.Local).AddTicks(585));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especificoes",
                table: "Bicicletas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2050), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2056), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2065), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2071), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2077), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2086), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2091), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2096), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2105), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(2111), "" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 45, 26, 191, DateTimeKind.Local).AddTicks(1934));
        }
    }
}
