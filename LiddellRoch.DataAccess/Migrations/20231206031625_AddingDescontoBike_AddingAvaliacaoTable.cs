using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingDescontoBike_AddingAvaliacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescontoPromocao",
                table: "Bicicletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvaliacaoCompra = table.Column<int>(type: "int", nullable: false),
                    ComentarioCompra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Bicicletas_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Bicicletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3155), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3163), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3172), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3178), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3183), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3193), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3197), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3202), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3210), 0 });

            migrationBuilder.UpdateData(
                table: "Bicicletas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CriadoEm", "DescontoPromocao" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 16, 25, 828, DateTimeKind.Local).AddTicks(3216), 0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_BicicletaId",
                table: "Avaliacoes",
                column: "BicicletaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "DescontoPromocao",
                table: "Bicicletas");

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
        }
    }
}
