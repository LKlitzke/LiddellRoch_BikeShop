using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingMarcaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicicletas_Marca_MarcaId",
                table: "Bicicletas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marca",
                table: "Marca");

            migrationBuilder.RenameTable(
                name: "Marca",
                newName: "Marcas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bicicletas_Marcas_MarcaId",
                table: "Bicicletas",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicicletas_Marcas_MarcaId",
                table: "Bicicletas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marcas",
                table: "Marcas");

            migrationBuilder.RenameTable(
                name: "Marcas",
                newName: "Marca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marca",
                table: "Marca",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Marca",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 11, 2, 16, 54, 15, 730, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.AddForeignKey(
                name: "FK_Bicicletas_Marca_MarcaId",
                table: "Bicicletas",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
