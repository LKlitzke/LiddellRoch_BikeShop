using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingComponenteReferenceToBicicleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Bicicletas_BicicletaId",
                table: "Componente");

            migrationBuilder.AlterColumn<int>(
                name: "BicicletaId",
                table: "Componente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Bicicletas_BicicletaId",
                table: "Componente");

            migrationBuilder.AlterColumn<int>(
                name: "BicicletaId",
                table: "Componente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 2, 17, 14, 15, 440, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_Bicicletas_BicicletaId",
                table: "Componente",
                column: "BicicletaId",
                principalTable: "Bicicletas",
                principalColumn: "Id");
        }
    }
}
