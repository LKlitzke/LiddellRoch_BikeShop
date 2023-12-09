using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangingComponenteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Bicicletas_BicicletaId",
                table: "Componente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Componente",
                table: "Componente");

            migrationBuilder.RenameTable(
                name: "Componente",
                newName: "Componentes");

            migrationBuilder.RenameIndex(
                name: "IX_Componente_BicicletaId",
                table: "Componentes",
                newName: "IX_Componentes_BicicletaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Componentes",
                table: "Componentes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 836, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 19, 39, 48, 835, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Bicicletas_BicicletaId",
                table: "Componentes",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Bicicletas_BicicletaId",
                table: "Componentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Componentes",
                table: "Componentes");

            migrationBuilder.RenameTable(
                name: "Componentes",
                newName: "Componente");

            migrationBuilder.RenameIndex(
                name: "IX_Componentes_BicicletaId",
                table: "Componente",
                newName: "IX_Componente_BicicletaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Componente",
                table: "Componente",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 20, 21, 115, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_Bicicletas_BicicletaId",
                table: "Componente",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
