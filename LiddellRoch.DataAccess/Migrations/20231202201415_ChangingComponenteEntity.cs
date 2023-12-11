using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangingComponenteEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Componente");

            migrationBuilder.DropColumn(
                name: "Icone",
                table: "Componente");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Componente",
                newName: "Valor");

            migrationBuilder.AddColumn<int>(
                name: "TipoComponenteId",
                table: "Componente",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoComponenteId",
                table: "Componente");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Componente",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Componente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icone",
                table: "Componente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
