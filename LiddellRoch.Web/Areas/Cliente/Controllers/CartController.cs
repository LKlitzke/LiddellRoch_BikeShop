using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Models;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace LiddellRoch.Web.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        [BindProperty]
        public CarrinhoComprasVm CarrinhoComprasVm { get; set; }

        public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CarrinhoComprasVm = new()
            {
                CarrinhoComprasList = _unitOfWork.CarrinhoCompras.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Bicicleta"),
                PedidoHeader = new()
            };

            IEnumerable<ImagemProduto> imagensProduto = _unitOfWork.ImagemProduto.GetAll();

            foreach (var cart in CarrinhoComprasVm.CarrinhoComprasList)
            {
                cart.Bicicleta.ImagensProduto = imagensProduto.Where(u => u.BicicletaId == cart.Bicicleta.Id).ToList();
                cart.Preco = cart.Bicicleta.Preco;
                //cart.Preco = GetPriceBasedOnQuantity(cart);
                CarrinhoComprasVm.PedidoHeader.TotalPedido += (cart.Preco * cart.Quantidade);
            }
            return View(CarrinhoComprasVm);
        }

        public IActionResult Resumo()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CarrinhoComprasVm = new()
            {
                CarrinhoComprasList = _unitOfWork.CarrinhoCompras.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Bicicleta"),
                PedidoHeader = new()
            };

            CarrinhoComprasVm.PedidoHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);

            CarrinhoComprasVm.PedidoHeader.Nome = CarrinhoComprasVm.PedidoHeader.ApplicationUser.Nome;
            CarrinhoComprasVm.PedidoHeader.Telefone = CarrinhoComprasVm.PedidoHeader.ApplicationUser.PhoneNumber;
            CarrinhoComprasVm.PedidoHeader.Endereco = CarrinhoComprasVm.PedidoHeader.ApplicationUser.Endereco;
            CarrinhoComprasVm.PedidoHeader.Cidade = CarrinhoComprasVm.PedidoHeader.ApplicationUser.Cidade;
            CarrinhoComprasVm.PedidoHeader.Estado = CarrinhoComprasVm.PedidoHeader.ApplicationUser.Estado;
            CarrinhoComprasVm.PedidoHeader.CodigoPostal = CarrinhoComprasVm.PedidoHeader.ApplicationUser.CodigoPostal;

            foreach (var cart in CarrinhoComprasVm.CarrinhoComprasList)
            {
                //cart.Product.ProductImages = productImages.Where(u => u.ProductId == cart.Product.Id).ToList();
                cart.Preco = cart.Bicicleta.Preco;
                //cart.Price = GetPriceBasedOnQuantity(cart);
                CarrinhoComprasVm.PedidoHeader.TotalPedido += (cart.Preco * cart.Quantidade);
            }
            return View(CarrinhoComprasVm);
        }

        [HttpPost]
        [ActionName("Resumo")]
        public IActionResult ResumoPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CarrinhoComprasVm.CarrinhoComprasList = _unitOfWork.CarrinhoCompras
                .GetAll(u => u.ApplicationUserId == userId, includeProperties: "Bicicleta");

            CarrinhoComprasVm.PedidoHeader.DataPedido = DateTime.Now;
            CarrinhoComprasVm.PedidoHeader.ApplicationUserId = userId;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);

            foreach (var item in CarrinhoComprasVm.CarrinhoComprasList)
            {
                //item.Price = GetPriceBasedOnQuantity(item);
                item.Preco = item.Bicicleta.Preco;
                CarrinhoComprasVm.PedidoHeader.TotalPedido += (item.Preco * item.Quantidade);

                // Atualiza estoque do item
                item.Bicicleta.Estoque -= item.Quantidade;
                _unitOfWork.Bicicleta.Update(item.Bicicleta);
            }

            if (applicationUser.EmpresaId.GetValueOrDefault() == 0)
            {
                // Customer
                CarrinhoComprasVm.PedidoHeader.StatusPagamento = SD.PaymentStatusPending;
                CarrinhoComprasVm.PedidoHeader.StatusPedido = SD.StatusPending;
            }
            else
            {
                // Company
                CarrinhoComprasVm.PedidoHeader.StatusPagamento = SD.PaymentStatusDelayedPayment;
                CarrinhoComprasVm.PedidoHeader.StatusPedido = SD.StatusApproved;
            }
            _unitOfWork.PedidoHeader.Add(CarrinhoComprasVm.PedidoHeader);
            _unitOfWork.Save();

            foreach (var cart in CarrinhoComprasVm.CarrinhoComprasList)
            {
                PedidoDetalhe pedidoDetalhe = new()
                {
                    BicicletaId = cart.BicicletaId,
                    PedidoHeaderId = CarrinhoComprasVm.PedidoHeader.Id,
                    Preco = cart.Preco,
                    Quantidade = cart.Quantidade
                };
                _unitOfWork.PedidoDetalhes.Add(pedidoDetalhe);
                _unitOfWork.Save();
            }

            // Only for customers
            if (applicationUser.EmpresaId.GetValueOrDefault() == 0)
            {
                // Codigo do STRIPE
                var domain = Request.Scheme + "://" + Request.Host.Value + "/";
                var options = new SessionCreateOptions
                {
                    // Provavelmente vai dar erro aqui \/
                    SuccessUrl = domain + $"cliente/cart/ConfirmacaoPedido?id={CarrinhoComprasVm.PedidoHeader.Id}",
                    CancelUrl = domain + "cliente/cart/index",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                foreach (var item in CarrinhoComprasVm.CarrinhoComprasList)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        // PriceData => Objeto para dados
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Preco * 100), // Conversão de dolares para long -- 100.30 -> 10030
                            Currency = "brl", // converter usd to brl
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Bicicleta.Nome
                            }
                        },
                        Quantity = item.Quantidade
                    };
                    options.LineItems.Add(sessionLineItem);
                }

                var service = new SessionService();
                Session session = service.Create(options);
                _unitOfWork.PedidoHeader.UpdateStripePaymentID(CarrinhoComprasVm.PedidoHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.Save();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303); // Redirect to URL
            }

            return RedirectToAction(nameof(ConfirmacaoPedido), new { id = CarrinhoComprasVm.PedidoHeader.Id });
        }


        public IActionResult ConfirmacaoPedido(int id)
        {
            PedidoHeader pedidoHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == id, includeProperties: "ApplicationUser");

            // Customer
            if (pedidoHeader.StatusPagamento != SD.PaymentStatusDelayedPayment)
            {
                var service = new SessionService();
                Session session = service.Get(pedidoHeader.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.PedidoHeader.UpdateStripePaymentID(id, session.Id, session.PaymentIntentId);
                    _unitOfWork.PedidoHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
                }
                HttpContext.Session.Clear();

            }

            List<CarrinhoCompras> carts = _unitOfWork.CarrinhoCompras
                .GetAll(u => u.ApplicationUserId == pedidoHeader.ApplicationUserId).ToList();

            _unitOfWork.CarrinhoCompras.RemoveRange(carts);
            _unitOfWork.Save();

            return View(id);
        }


        // Operação de adicionar no carrinho
        public IActionResult Mais(int cartId)
        {
            var cartFromDb = _unitOfWork.CarrinhoCompras.GetFirstOrDefault(u => u.Id == cartId);
            cartFromDb.Quantidade += 1;
            _unitOfWork.CarrinhoCompras.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        // Operação de remover no carrinho
        public IActionResult Menos(int cartId)
        {
            var cartFromDb = _unitOfWork.CarrinhoCompras.GetFirstOrDefault(u => u.Id == cartId, tracked: true);
            if (cartFromDb.Quantidade <= 1)
            {
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.CarrinhoCompras
                   .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);

                _unitOfWork.CarrinhoCompras.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Quantidade -= 1;
                _unitOfWork.CarrinhoCompras.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.CarrinhoCompras.GetFirstOrDefault(u => u.Id == cartId, tracked: true);

            HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.CarrinhoCompras
              .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);

            _unitOfWork.CarrinhoCompras.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //private decimal GetPrecoPorQuantidade(CarrinhoCompras carrinhoCompras)
        //{
        //    // Refatorar?
        //    if (carrinhoCompras.Quantidade <= 50)
        //    {
        //        return carrinhoCompras.Bicicleta.Preco;
        //    }
        //    else
        //    {
        //        if (carrinhoCompras.Quantidade <= 100)
        //        {
        //            return carrinhoCompras.Product.Price50;
        //        }
        //        else
        //        {
        //            return shoppingCart.Product.Price100;
        //        }
        //    }
        //}
    }
}
