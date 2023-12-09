using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangingAvaliacaoReferenceToPedidoHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_ApplicationUserId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_ApplicationUserId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Avaliacoes");

            migrationBuilder.AddColumn<int>(
                name: "PedidoHeaderId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_PedidoHeaderId",
                table: "Avaliacoes",
                column: "PedidoHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_PedidoHeaders_PedidoHeaderId",
                table: "Avaliacoes",
                column: "PedidoHeaderId",
                principalTable: "PedidoHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_PedidoHeaders_PedidoHeaderId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_PedidoHeaderId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "PedidoHeaderId",
                table: "Avaliacoes");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Avaliacoes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CriadoEm",
                value: new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ApplicationUserId",
                table: "Avaliacoes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_ApplicationUserId",
                table: "Avaliacoes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
