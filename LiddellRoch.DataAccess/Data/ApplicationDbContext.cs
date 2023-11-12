using LiddellRoch.Models;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LiddellRoch.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // DbSets
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<CarrinhoCompras> CarrinhoCompras { get; set; }
        public DbSet<ImagemProduto> ImagemProdutos { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PedidoHeader> PedidoHeaders { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Mountain Bike", OrdemExibicao = 1, CriadoEm = DateTime.Now },
                new Categoria { Id = 2, Nome = "Estrada", OrdemExibicao = 2, CriadoEm = DateTime.Now },
                new Categoria { Id = 3, Nome = "Gravel", OrdemExibicao = 3, CriadoEm = DateTime.Now },
                new Categoria { Id = 4, Nome = "Elétrica", OrdemExibicao = 4, CriadoEm = DateTime.Now },
                new Categoria { Id = 5, Nome = "Urbano e Lazer", OrdemExibicao = 5, CriadoEm = DateTime.Now },
                new Categoria { Id = 6, Nome = "BMX", OrdemExibicao = 6, CriadoEm = DateTime.Now },
                new Categoria { Id = 7, Nome = "Clássico", OrdemExibicao = 7, CriadoEm = DateTime.Now }
            );

            modelBuilder.Entity<Marca>().HasData(
                new Marca
                {
                    Id = 1,
                    Nome = "Oggi",
                    PaisOrigem = "Brasil",
                    IconUrl = @"\images\marcas\oggi_logo.svg",
                    SiteOficial = @"https://oggibikes.com.br/",
                    CriadoEm = DateTime.Now
                },
                new Marca
                {
                    Id = 2,
                    Nome = "Cannondale",
                    PaisOrigem = "Estados Unidos da América",
                    IconUrl = @"\images\marcas\cannondale_logo.svg",
                    SiteOficial = @"https://www.cannondale.com/pt-br",
                    CriadoEm = DateTime.Now
                },
                new Marca
                {
                    Id = 3,
                    Nome = "Caloi",
                    PaisOrigem = "Brasil",
                    IconUrl = @"\images\marcas\caloi_logo.png",
                    SiteOficial = @"https://caloi.com/",
                    CriadoEm = DateTime.Now
                },
                new Marca
                {
                    Id = 4,
                    Nome = "Specialized",
                    PaisOrigem = "Estados Unidos da América",
                    IconUrl = @"\images\marcas\specialized_logo.svg",
                    SiteOficial = @"https://www.specialized.com/br/pt",
                    CriadoEm = DateTime.Now
                },
                new Marca
                {
                    Id = 5,
                    Nome = "TSW",
                    PaisOrigem = "África do Sul",
                    IconUrl = @"\images\marcas\tsw_logo.svg",
                    SiteOficial = @"https://www.tsw.com/",
                    CriadoEm = DateTime.Now
                },
                new Marca
                {
                    Id = 6,
                    Nome = "Sense",
                    PaisOrigem = "Brasil",
                    IconUrl = @"\images\marcas\sense_logo.png",
                    SiteOficial = @"https://sensebike.com.br/",
                    CriadoEm = DateTime.Now
                },
                new Marca
                {
                    Id = 7,
                    Nome = "Scott",
                    PaisOrigem = "Suiça",
                    IconUrl = @"\images\marcas\scott_logo.svg",
                    SiteOficial = @"https://www.scott-sports.com/br/pt/",
                    CriadoEm = DateTime.Now
                }
            );

            modelBuilder.Entity<Empresa>().HasData(
                new Empresa
                {
                    Id = 1,
                    Nome = "Uprise Eventos",
                    Endereco = "Av Arthur Haese",
                    Cidade = "Marechal Floriano",
                    CodigoPostal = "29255-000",
                    Estado = "ES",
                    Telefone = "1234567890",
                    CriadoEm = DateTime.Now
                },
                new Empresa
                {
                    Id = 2,
                    Nome = "Agência AJM",
                    Endereco = "Tv. Augusto Schwambach",
                    Cidade = "Domingos Martins",
                    CodigoPostal = "29260-000",
                    Estado = "ES",
                    Telefone = "0987654321",
                    CriadoEm = DateTime.Now
                },
                new Empresa
                {
                    Id = 3,
                    Nome = "EryZ FuturAI",
                    Endereco = "Av. Brg. Eduardo Gomes",
                    Cidade = "Serra",
                    CodigoPostal = "29160-904",
                    Estado = "ES",
                    Telefone = "1029384756",
                    CriadoEm = DateTime.Now
                },
                new Empresa
                {
                    Id = 4,
                    Nome = "Dani Floricultura",
                    Endereco = "Av. Violet Hill",
                    Cidade = "São Paulo",
                    CodigoPostal = "01153-000",
                    Estado = "SP",
                    Telefone = "9925266237",
                    CriadoEm = DateTime.Now
                }
            );

            modelBuilder.Entity<Bicicleta>().HasData(
                new Bicicleta
                {
                    Id = 1,
                    Nome = "Big Wheel 7.4 2022",
                    Descricao = "A nova Big Wheel 7.4 2022 faz parte da linha de bicicletas de alta performance em alumínio da Oggi.\r\nO novo quadro com a geometria mais agressiva e moderna é ideal para quem deseja encarar desafios técnicos maiores, sem perder o rendimento em outras condições do cross-country. Além disso ela conta com cabeamento interno e padrão Boost, seguindo as tendências das grandes marcas importadas. Esse novo padrão possibilita ao ciclista fazer upgrades com componentes de alto padrão disponíveis no mercado.\r\nOs componentes que equipam essa nova versão foram especialmente selecionados, afim de entregar máxima performance em qualquer ocasião além de um visual moderno e agressivo. Conta com sistema de transmissão Shimano SLX de 12 velocidades, suspensão Manitou Machete com trava no guidão e 100 milímetros de curso e cockpit com componentes ITM NH1.",
                    Preco = 10590.00m,
                    Peso = 12.5,
                    Estoque = 50,
                    Cores = string.Join(",", new List<Cores> { Cores.Black, Cores.DarkGray, Cores.Red }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 1,
                    MarcaId = 1,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 2,
                    Nome = "Agile Squadra XX1 AXS",
                    Descricao = "A Agile Squadra XX1 AXS é uma bicicleta hardtail super leve, com desempenho suficiente para correr etapas da Copa do Mundo de MTB. Para isso, ela aposta no quadro e nas rodas de fibra de carbono, nas suspensão Fox 32 Factory Step Cast Kashima, no grupo eletrônico topo de linha e na geometria mais avançada jamais criada pela engenharia da Oggi.\r\n\r\nPeso total de 9.3Kg com novo quadro em carbono Super Light Oggi, rodas DT Swiss XRC 1501 de 1600g em carbono, cubos DT 250 e roda livre Ratchet EXP 36;\r\nGrupo eletrônico SRAM Eagle XX1 AXS 12V, um dos mais leves e modernos do mundo;\r\nSuspensão Fox 32 Factory Step-Cast Kashima 10mm, câmara de ar Float Evol e cartucho FIT 4 com trava no guidão, com excelente leitura de terreno e suporte nas trilhas inclinadas;\r\nCanote retrátil eletrônico SRAM Reverb AXS, pneus Kenda Booster Pro 2.4 e freios Level Ultimate para total controle.",
                    Preco = 44900.00m,
                    Peso = 9.3,
                    Estoque = 20,
                    Cores = string.Join(",", new List<Cores> { Cores.Gold }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 1,
                    MarcaId = 1,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 3,
                    Nome = "Velloce Disc 2022",
                    Descricao = "A combinação entre esportividade, rigidez, baixo peso e conforto faz com que a nova Oggi Velloce Disc 2022 tenha um grande desempenho em diversos lugares, graças ao seu novo quadro, proporcionando mais agressividade e aerodinâmica ao ciclista.",
                    Preco = 3949.00m,
                    Peso = 11.7,
                    Estoque = 30,
                    Cores = string.Join(",", new List<Cores> { Cores.DarkGray, Cores.DarkRed }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L, Tamanhos.XL }),
                    CategoriaId = 2,
                    MarcaId = 1,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 4,
                    Nome = "F-Si Hi-MOD 1",
                    Descricao = "Uma pura mountain bike de XC Repleta de atributos de performance que asseguram a vitória e pesando quase nada. Quadro em carbono Hi-MOD BallisTec / Garfo Lefty Ocho Carbon 100mm / conectividade com App Cannondale integrado\r\nCâmbios Shimano XTR 12 velocidades / pedivela HollowGram\r\nJogo de rodas de carbono HollowGram 25 / guidão de carbono Cannondale 1 / canote ENVE.",
                    Preco = 75899.00m,
                    Peso = 8.9,
                    Estoque = 10,
                    Cores = string.Join(",", new List<Cores> { Cores.Black }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 1,
                    MarcaId = 2,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 5,
                    Nome = "Topstone 2",
                    Descricao = "Uma pura mountain bike de XC Repleta de atributos de performance que asseguram a vitória e pesando quase nada. Quadro em carbono Hi-MOD BallisTec / Garfo Lefty Ocho Carbon 100mm / conectividade com App Cannondale integrado\r\nCâmbios Shimano XTR 12 velocidades / pedivela HollowGram\r\nJogo de rodas de carbono HollowGram 25 / guidão de carbono Cannondale 1 / canote ENVE.",
                    Preco = 14999.00m,
                    Peso = 13.1,
                    Estoque = 50,
                    Cores = string.Join(",", new List<Cores> { Cores.MediumVioletRed }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 3,
                    MarcaId = 2,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 6,
                    Nome = "Active 2023",
                    Descricao = "Para você, que valoriza a mobilidade urbana e ainda quer aproveitar sua bike para a prática esportiva, a Activ é a bike ideal. Uma bicicleta versátil, prática, segura e de fácil manutenção, que lhe permite ir além dos centros urbanos e descobrir novas sensações.\r\n\r\nA Activ é oferecida em duas cores e vem montada com seu quadro em alumínio leve, transmissão Shimano Altus 27 velocidades, freios a disco hidráulico, pneus 700X38 e uma linda bolsa, especialmente desenvolvida pela Draisiana.",
                    Preco = 3890.00m,
                    Peso = 12.0,
                    Estoque = 100,
                    Cores = string.Join(",", new List<Cores> { Cores.Beige, Cores.DarkSeaGreen }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.XS, Tamanhos.S, Tamanhos.M, Tamanhos.L, Tamanhos.XL, Tamanhos.XXL }),
                    CategoriaId = 5,
                    MarcaId = 6,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 7,
                    Nome = "Penny-Farthing",
                    Descricao = "Penny-farthing, high wheel e ordinary são termos utilizados para descrever um tipo de bicicleta com a roda dianteira de grande dimensão e a traseira pequena. O modelo tornou-se popular depois do boneshaker e antes do desenvolvimento da \"bicicleta segura\", na década de 1880. Foram os primeiros veículos a serem chamados bicicletas.",
                    Preco = 8000.00m,
                    Peso = 18.0,
                    Estoque = 5,
                    Cores = string.Join(",", new List<Cores> { Cores.Black }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.M }),
                    CategoriaId = 7,
                    MarcaId = 1,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 8,
                    Nome = "Spark RC World Cup Evo",
                    Descricao = "A Spark RC World Cup é construída com um quadro de carbono HMX de alta qualidade, que combina rigidez e leveza para uma transferência de potência eficiente e ágil nas trilhas. A fibra de carbono HMX da Scott é conhecida por sua natureza leve e excelente rigidez, o que permite a construção de bicicletas com maior transferência de potência e características de manuseio responsivas. Ao utilizar a fibra de carbono HMX, a Scott produz quadros e componentes leves, mas incrivelmente fortes, permitindo que os ciclistas maximizem seu desempenho na estrada ou na trilha.",
                    Preco = 114999.00m,
                    Peso = 10.4,
                    Estoque = 3,
                    Cores = string.Join(",", new List<Cores> { Cores.DarkGray }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 1,
                    MarcaId = 7,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 9,
                    Nome = "400 Comfort",
                    Descricao = "Passear de bike é algo extremamente prazeroso, seja em um fim de tarde na praça, ciclovia, e a Caloi desenvolveu a bike perfeita para você fazer esses passeios. A Caloi 400 conta com geometria confort, propiciando uma posição de pilotagem ereta e juntamente ao guidão com uma ergonomia mais elevada oferecendo maior conforto ao pedalar. Além do mais o pedivela ficou levemente posicionado mais a frente, garantindo que a pedalada seja mais fácil e agradável. E para movimenta-la a Caloi selecionou um sistema de transmissão Shimano, sinônimo de confiabilidade e resistência com 21 velocidades, para você poder usufruir de sua bike com a total tranquilidade para relaxar.",
                    Preco = 1300.00m,
                    Peso = 13,
                    Estoque = 30,
                    Cores = string.Join(",", new List<Cores> { Cores.Black, Cores.Green, Cores.Yellow }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 5,
                    MarcaId = 3,
                    CriadoEm = DateTime.Now
                },
                new Bicicleta
                {
                    Id = 10,
                    Nome = "Cattura Pro Carbon GX 2022",
                    Descricao = "A Cattura Pro apresenta um design moderno e robusto, além de trazer tudo o que um praticante mountain bike busca e espera de uma bike dessa categoria. Apresentando uma geometria race, a Cattura é uma bike muito ágil e tem uma resposta excelente nos mais diversos terrenos com seu quadro projetado em full carbon, possuindo ainda excelente rigidez e baixo peso.",
                    Preco = 24799.00m,
                    Peso = 12.1,
                    Estoque = 20,
                    Cores = string.Join(",", new List<Cores> { Cores.Yellow, Cores.DarkGray }),
                    Tamanhos = string.Join(",", new List<Tamanhos> { Tamanhos.S, Tamanhos.M, Tamanhos.L }),
                    CategoriaId = 1,
                    MarcaId = 1,
                    CriadoEm = DateTime.Now
                }
            );
        }
    }
}
