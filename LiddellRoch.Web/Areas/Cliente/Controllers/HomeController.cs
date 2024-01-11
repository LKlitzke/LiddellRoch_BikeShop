﻿using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Utility;
using LiddellRoch.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;

namespace LiddellRoch.Web.Areas.Cliente.Controllers
{
	[Area("Cliente")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork _unitOfWork;
		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			IEnumerable<Bicicleta> bikeList = _unitOfWork.Bicicleta.GetAll(includeProperties: "Categoria,Marca,ImagensProduto,Avaliacoes");

			ViewData["MarcasList"] = _unitOfWork.Marca.GetAll().ToList();
			return View(bikeList);
		}

		[HttpGet]
		public IActionResult ListaBikes(string? nomeBusca)
		{
			var tamEnumList = Enum.GetValues(typeof(Tamanhos)).Cast<Tamanhos>();
			IEnumerable<Bicicleta> bikeList = _unitOfWork.Bicicleta.GetAll(b => b.Estoque > 0, includeProperties: "Categoria,Marca,ImagensProduto,Avaliacoes");

            if (!string.IsNullOrEmpty(nomeBusca))
                bikeList = bikeList.Where(b => b.Nome.ToLower().Contains(nomeBusca.ToLower())).ToList();

            ListaBikesVm listaBikesVm = new()
			{
				BicicletasList = bikeList.ToList(),

				CategoriasList = _unitOfWork.Categoria.GetAll().Select(u => new SelectListItem
				{
					Text = u.Nome,
					Value = u.Id.ToString()
				}).OrderBy(e => e.Text),

				MarcasList = _unitOfWork.Marca.GetAll().Select(marca => new SelectListItem
				{
					Text = marca.Nome,
					Value = marca.Id.ToString()
				}).OrderBy(e => e.Text)

			};

			ViewData["nomeBusca"] = nomeBusca;

			return View(listaBikesVm);
		}

		[HttpPost]
		public IActionResult GetListaBikesFiltro(int[] marcasIdFilter, int[] categoriasIdFilter, string? precoMinimo, string? precoMaximo, string? nomeBusca)
		{
			var tamEnumList = Enum.GetValues(typeof(Tamanhos)).Cast<Tamanhos>();
			var formValues = new List<string>();
			IEnumerable<Bicicleta> bikeList = _unitOfWork.Bicicleta
				.GetAll(b => b.Estoque > 0, includeProperties: "Categoria,Marca,ImagensProduto,Avaliacoes");

			if (marcasIdFilter.Any())
				bikeList = bikeList.Where(b => marcasIdFilter.Contains(b.MarcaId)).ToList();

			if (categoriasIdFilter.Any())
				bikeList = bikeList.Where(b => categoriasIdFilter.Contains(b.CategoriaId)).ToList();

			if (!string.IsNullOrEmpty(precoMinimo))
				bikeList = bikeList.Where(b => b.ValorComDesconto >= decimal.Parse(precoMinimo)).ToList();

			if (!string.IsNullOrEmpty(precoMaximo))
				bikeList = bikeList.Where(b => b.ValorComDesconto <= decimal.Parse(precoMaximo)).ToList();

			if (!string.IsNullOrEmpty(nomeBusca))
				bikeList = bikeList.Where(b => b.Nome.ToLower().Contains(nomeBusca.ToLower())).ToList();

			//var categoriaFiltro = new List<string>();
			//var marcaFiltro = new List<string>();
			//var precoMinFiltro = "";
			//var precoMaxFiltro = "";


			//if (form != null)
			//         {
			//	categoriaFiltro = form["categorias[]"].ToString().Split(',',StringSplitOptions.RemoveEmptyEntries).ToList();
			//	marcaFiltro = form["marcas[]"].ToString().Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
			//             precoMinFiltro = form["precoMinimo"];
			//	precoMaxFiltro = form["precoMaximo"];

			//             if (!categoriaFiltro.IsNullOrEmpty())
			//                 bikeList = bikeList.Where(b => categoriaFiltro.Contains(b.CategoriaId.ToString()));

			//             if (!query.IsNullOrEmpty())
			//             {
			//                 bikeList = bikeList.Where(b => b.Nome.ToLower().Contains(query.ToLower()));
			//             }
			//}


			return PartialView("_BikeFilterPartial", bikeList);
		}


		public IActionResult Detalhes(int bikeId)
		{
			CarrinhoCompras cart = new()
			{
				Bicicleta = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == bikeId, includeProperties: "Categoria,Marca,ImagensProduto,Avaliacoes,Componentes"),
				Quantidade = 1,
				BicicletaId = bikeId
			};
			return View(cart);
		}

		[HttpPost]
		[Authorize]
		public IActionResult Detalhes(CarrinhoCompras shoppingCart)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			shoppingCart.ApplicationUserId = userId;
			var item = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == shoppingCart.BicicletaId);
			if (item.Estoque < shoppingCart.Quantidade)
			{
				TempData["error"] = "Unidades selecionadas acima do estoque!";
				CarrinhoCompras cart = new()
				{
					Bicicleta = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == item.Id, includeProperties: "Categoria,Marca,ImagensProduto,Avaliacoes"),
					Quantidade = 1,
					BicicletaId = item.Id
				};
				return View(cart);
			}

			CarrinhoCompras cartDb = _unitOfWork.CarrinhoCompras.GetFirstOrDefault(u => u.ApplicationUserId == userId
			&& u.BicicletaId == shoppingCart.BicicletaId);

			if (cartDb != null)
			{
				cartDb.Quantidade += shoppingCart.Quantidade;
				_unitOfWork.CarrinhoCompras.Update(cartDb);
				_unitOfWork.Save();
			}
			else
			{
				_unitOfWork.CarrinhoCompras.Add(shoppingCart);
				_unitOfWork.Save();
				HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.CarrinhoCompras.GetAll(u => u.ApplicationUserId == userId).Count());
			}
			TempData["success"] = "Carrinho atualizado com sucesso!";
			return RedirectToAction(nameof(Index));
		}

		public IActionResult SobreNos()
		{
			return View();
		}

        public IActionResult Privacidade()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}