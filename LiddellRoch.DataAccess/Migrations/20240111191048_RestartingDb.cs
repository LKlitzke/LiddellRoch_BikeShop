using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiddellRoch.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RestartingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OrdemExibicao = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteOficial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bicicletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Cores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescontoPromocao = table.Column<int>(type: "int", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Tamanhos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bicicletas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bicicletas_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusPedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroRastreio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transportadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimentoPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompras_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompras_Bicicletas_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Bicicletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoComponenteId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componentes_Bicicletas_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Bicicletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemProdutos_Bicicletas_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Bicicletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    PedidoHeaderId = table.Column<int>(type: "int", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvaliacaoCompra = table.Column<int>(type: "int", nullable: false),
                    ComentarioCompra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Bicicletas_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Bicicletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_PedidoHeaders_PedidoHeaderId",
                        column: x => x.PedidoHeaderId,
                        principalTable: "PedidoHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalhes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoHeaderId = table.Column<int>(type: "int", nullable: false),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_Bicicletas_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Bicicletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalhes_PedidoHeaders_PedidoHeaderId",
                        column: x => x.PedidoHeaderId,
                        principalTable: "PedidoHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CriadoEm", "Nome", "OrdemExibicao" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8476), "Mountain Bike", 1 },
                    { 2, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8489), "Estrada", 2 },
                    { 3, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8490), "Gravel", 3 },
                    { 4, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8491), "Elétrica", 4 },
                    { 5, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8492), "Urbano e Lazer", 5 },
                    { 6, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8493), "BMX", 6 },
                    { 7, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8494), "Clássico", 7 }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Cidade", "CodigoPostal", "CriadoEm", "Endereco", "Estado", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "Marechal Floriano", "29255-000", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8653), "Av Arthur Haese", "ES", "Uprise Eventos", "1234567890" },
                    { 2, "Domingos Martins", "29260-000", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8654), "Tv. Augusto Schwambach", "ES", "Agência AJM", "0987654321" },
                    { 3, "Serra", "29160-904", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8655), "Av. Brg. Eduardo Gomes", "ES", "EryZ FuturAI", "1029384756" },
                    { 4, "São Paulo", "01153-000", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8656), "Av. Violet Hill", "SP", "Dani Floricultura", "9925266237" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CriadoEm", "IconUrl", "Nome", "PaisOrigem", "SiteOficial" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8624), "\\images\\marcas\\oggi_logo.svg", "Oggi", "Brasil", "https://oggibikes.com.br/" },
                    { 2, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8625), "\\images\\marcas\\cannondale_logo.svg", "Cannondale", "Estados Unidos da América", "https://www.cannondale.com/pt-br" },
                    { 3, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8626), "\\images\\marcas\\caloi_logo.png", "Caloi", "Brasil", "https://caloi.com/" },
                    { 4, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8627), "\\images\\marcas\\specialized_logo.svg", "Specialized", "Estados Unidos da América", "https://www.specialized.com/br/pt" },
                    { 5, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8628), "\\images\\marcas\\tsw_logo.svg", "TSW", "África do Sul", "https://www.tsw.com/" },
                    { 6, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8629), "\\images\\marcas\\sense_logo.png", "Sense", "Brasil", "https://sensebike.com.br/" },
                    { 7, new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8630), "\\images\\marcas\\scott_logo.svg", "Scott", "Suiça", "https://www.scott-sports.com/br/pt/" }
                });

            migrationBuilder.InsertData(
                table: "Bicicletas",
                columns: new[] { "Id", "CategoriaId", "Cores", "CriadoEm", "DescontoPromocao", "Descricao", "Estoque", "MarcaId", "Nome", "Peso", "Preco", "Tamanhos" },
                values: new object[,]
                {
                    { 1, 1, "Black,DarkGray,Red", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8746), 0, "A nova Big Wheel 7.4 2022 faz parte da linha de bicicletas de alta performance em alumínio da Oggi.\r\nO novo quadro com a geometria mais agressiva e moderna é ideal para quem deseja encarar desafios técnicos maiores, sem perder o rendimento em outras condições do cross-country. Além disso ela conta com cabeamento interno e padrão Boost, seguindo as tendências das grandes marcas importadas. Esse novo padrão possibilita ao ciclista fazer upgrades com componentes de alto padrão disponíveis no mercado.\r\nOs componentes que equipam essa nova versão foram especialmente selecionados, afim de entregar máxima performance em qualquer ocasião além de um visual moderno e agressivo. Conta com sistema de transmissão Shimano SLX de 12 velocidades, suspensão Manitou Machete com trava no guidão e 100 milímetros de curso e cockpit com componentes ITM NH1.", 50, 1, "Big Wheel 7.4 2022", 12.5, 10590.00m, "S,M,L" },
                    { 2, 1, "Gold", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8753), 0, "A Agile Squadra XX1 AXS é uma bicicleta hardtail super leve, com desempenho suficiente para correr etapas da Copa do Mundo de MTB. Para isso, ela aposta no quadro e nas rodas de fibra de carbono, nas suspensão Fox 32 Factory Step Cast Kashima, no grupo eletrônico topo de linha e na geometria mais avançada jamais criada pela engenharia da Oggi.\r\n\r\nPeso total de 9.3Kg com novo quadro em carbono Super Light Oggi, rodas DT Swiss XRC 1501 de 1600g em carbono, cubos DT 250 e roda livre Ratchet EXP 36;\r\nGrupo eletrônico SRAM Eagle XX1 AXS 12V, um dos mais leves e modernos do mundo;\r\nSuspensão Fox 32 Factory Step-Cast Kashima 10mm, câmara de ar Float Evol e cartucho FIT 4 com trava no guidão, com excelente leitura de terreno e suporte nas trilhas inclinadas;\r\nCanote retrátil eletrônico SRAM Reverb AXS, pneus Kenda Booster Pro 2.4 e freios Level Ultimate para total controle.", 20, 1, "Agile Squadra XX1 AXS", 9.3000000000000007, 44900.00m, "M,L" },
                    { 3, 2, "DarkGray,DarkRed", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8761), 0, "A combinação entre esportividade, rigidez, baixo peso e conforto faz com que a nova Oggi Velloce Disc 2022 tenha um grande desempenho em diversos lugares, graças ao seu novo quadro, proporcionando mais agressividade e aerodinâmica ao ciclista.", 30, 1, "Velloce Disc 2022", 11.699999999999999, 3949.00m, "S,M,L,XL" },
                    { 4, 1, "Black", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8767), 0, "Uma pura mountain bike de XC Repleta de atributos de performance que asseguram a vitória e pesando quase nada. Quadro em carbono Hi-MOD BallisTec / Garfo Lefty Ocho Carbon 100mm / conectividade com App Cannondale integrado\r\nCâmbios Shimano XTR 12 velocidades / pedivela HollowGram\r\nJogo de rodas de carbono HollowGram 25 / guidão de carbono Cannondale 1 / canote ENVE.", 10, 2, "F-Si Hi-MOD 1", 8.9000000000000004, 75899.00m, "S,M,L" },
                    { 5, 3, "MediumVioletRed", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8773), 0, "Uma pura mountain bike de XC Repleta de atributos de performance que asseguram a vitória e pesando quase nada. Quadro em carbono Hi-MOD BallisTec / Garfo Lefty Ocho Carbon 100mm / conectividade com App Cannondale integrado\r\nCâmbios Shimano XTR 12 velocidades / pedivela HollowGram\r\nJogo de rodas de carbono HollowGram 25 / guidão de carbono Cannondale 1 / canote ENVE.", 50, 2, "Topstone 2", 13.1, 14999.00m, "S,M,L" },
                    { 6, 5, "Beige,DarkSeaGreen", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8782), 0, "Para você, que valoriza a mobilidade urbana e ainda quer aproveitar sua bike para a prática esportiva, a Activ é a bike ideal. Uma bicicleta versátil, prática, segura e de fácil manutenção, que lhe permite ir além dos centros urbanos e descobrir novas sensações.\r\n\r\nA Activ é oferecida em duas cores e vem montada com seu quadro em alumínio leve, transmissão Shimano Altus 27 velocidades, freios a disco hidráulico, pneus 700X38 e uma linda bolsa, especialmente desenvolvida pela Draisiana.", 100, 6, "Active 2023", 12.0, 3890.00m, "XS,S,M,L,XL,XXL" },
                    { 7, 7, "Black", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8824), 0, "Penny-farthing, high wheel e ordinary são termos utilizados para descrever um tipo de bicicleta com a roda dianteira de grande dimensão e a traseira pequena. O modelo tornou-se popular depois do boneshaker e antes do desenvolvimento da \"bicicleta segura\", na década de 1880. Foram os primeiros veículos a serem chamados bicicletas.", 5, 1, "Penny-Farthing", 18.0, 8000.00m, "M" },
                    { 8, 1, "DarkGray", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8829), 0, "A Spark RC World Cup é construída com um quadro de carbono HMX de alta qualidade, que combina rigidez e leveza para uma transferência de potência eficiente e ágil nas trilhas. A fibra de carbono HMX da Scott é conhecida por sua natureza leve e excelente rigidez, o que permite a construção de bicicletas com maior transferência de potência e características de manuseio responsivas. Ao utilizar a fibra de carbono HMX, a Scott produz quadros e componentes leves, mas incrivelmente fortes, permitindo que os ciclistas maximizem seu desempenho na estrada ou na trilha.", 3, 7, "Spark RC World Cup Evo", 10.4, 114999.00m, "S,M,L" },
                    { 9, 5, "Black,Green,Yellow", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8839), 0, "Passear de bike é algo extremamente prazeroso, seja em um fim de tarde na praça, ciclovia, e a Caloi desenvolveu a bike perfeita para você fazer esses passeios. A Caloi 400 conta com geometria confort, propiciando uma posição de pilotagem ereta e juntamente ao guidão com uma ergonomia mais elevada oferecendo maior conforto ao pedalar. Além do mais o pedivela ficou levemente posicionado mais a frente, garantindo que a pedalada seja mais fácil e agradável. E para movimenta-la a Caloi selecionou um sistema de transmissão Shimano, sinônimo de confiabilidade e resistência com 21 velocidades, para você poder usufruir de sua bike com a total tranquilidade para relaxar.", 30, 3, "400 Comfort", 13.0, 1300.00m, "S,M,L" },
                    { 10, 1, "Yellow,DarkGray", new DateTime(2024, 1, 11, 16, 10, 48, 866, DateTimeKind.Local).AddTicks(8845), 0, "A Cattura Pro apresenta um design moderno e robusto, além de trazer tudo o que um praticante mountain bike busca e espera de uma bike dessa categoria. Apresentando uma geometria race, a Cattura é uma bike muito ágil e tem uma resposta excelente nos mais diversos terrenos com seu quadro projetado em full carbon, possuindo ainda excelente rigidez e baixo peso.", 20, 1, "Cattura Pro Carbon GX 2022", 12.1, 24799.00m, "S,M,L" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpresaId",
                table: "AspNetUsers",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_BicicletaId",
                table: "Avaliacoes",
                column: "BicicletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_PedidoHeaderId",
                table: "Avaliacoes",
                column: "PedidoHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bicicletas_CategoriaId",
                table: "Bicicletas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bicicletas_MarcaId",
                table: "Bicicletas",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompras_ApplicationUserId",
                table: "CarrinhoCompras",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompras_BicicletaId",
                table: "CarrinhoCompras",
                column: "BicicletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_BicicletaId",
                table: "Componentes",
                column: "BicicletaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemProdutos_BicicletaId",
                table: "ImagemProdutos",
                column: "BicicletaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_BicicletaId",
                table: "PedidoDetalhes",
                column: "BicicletaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalhes_PedidoHeaderId",
                table: "PedidoDetalhes",
                column: "PedidoHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoHeaders_ApplicationUserId",
                table: "PedidoHeaders",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "CarrinhoCompras");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "ImagemProdutos");

            migrationBuilder.DropTable(
                name: "PedidoDetalhes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bicicletas");

            migrationBuilder.DropTable(
                name: "PedidoHeaders");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
