using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingEspecificacoesToBikeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1268), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1275), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1284), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1290), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1296), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1307), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1311), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1316), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1347), "" });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CriadoEm", "Especificoes" },
                values: new object[] { new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1354), "" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Cidade", "CodigoPostal", "CriadoEm", "Endereco", "Estado", "Nome", "Telefone" },
                values: new object[] { 4, "São Paulo", "01153-000", new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1176), "Av. Violet Hill", "SP", "Dani Floricultura", "9925266237" });

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 15, 38, 9, 575, DateTimeKind.Local).AddTicks(1147));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Especificoes",
                table: "Bicicletas");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 5, 20, 10, 43, 267, DateTimeKind.Local).AddTicks(4009));
        }
    }
}
