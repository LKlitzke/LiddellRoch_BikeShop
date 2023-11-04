using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Utility;
using LiddellRoch.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
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

        public IActionResult AboutUs()
        {
            return View();
        }


        public IActionResult Privacy()
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