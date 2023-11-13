using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using LiddellRoch.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Issuing;
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
            IEnumerable<Bicicleta> bikeList = _unitOfWork.Bicicleta.GetAll(includeProperties: "Categoria,Marca,ImagensProduto"); //,ProductImage
            return View(bikeList);
        }

        public IActionResult Detalhes(int bikeId)
        {
            CarrinhoCompras cart = new()
            {
                Bicicleta = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == bikeId, includeProperties: "Categoria,Marca,ImagensProduto"),
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
                    Bicicleta = _unitOfWork.Bicicleta.GetFirstOrDefault(u => u.Id == item.Id, includeProperties: "Categoria,Marca,ImagensProduto"),
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
            //TempData["error"] = "Carrinho atualizado SSSSSS!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Pesquisa(string query)
        {
            if(query is null)
            {
                return RedirectToAction(nameof(Index));
            }
            var bikeList = _unitOfWork.Bicicleta.GetAll(b => b.Nome.ToLower().Contains(query.ToLower()));

            ViewData["query"] = query;
            return View(bikeList);
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