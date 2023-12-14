using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using System.Security.Claims;
using LiddellRoch.Models.ViewModels;
using LiddellRoch.Models;

namespace LiddellRoch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public PedidoVm PedidoVm { get; set; }
        public PedidoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes(int pedidoId)
        {
            PedidoVm = new()
            {
                PedidoHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == pedidoId, includeProperties: "ApplicationUser"),
                PedidoDetalhe = _unitOfWork.PedidoDetalhes.GetAll(u => u.PedidoHeaderId == pedidoId, includeProperties: "Bicicleta")
            };
            return View(PedidoVm);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Administrador + "," + SD.Role_Empregado)]
        public IActionResult AtualizaDetalhesPedido()
        {
            var pedidoHeaderDb = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == PedidoVm.PedidoHeader.Id);

            pedidoHeaderDb.Nome = PedidoVm.PedidoHeader.Nome;
            pedidoHeaderDb.Telefone = PedidoVm.PedidoHeader.Telefone;
            pedidoHeaderDb.Endereco = PedidoVm.PedidoHeader.Endereco;
            pedidoHeaderDb.Cidade = PedidoVm.PedidoHeader.Cidade;
            pedidoHeaderDb.Estado = PedidoVm.PedidoHeader.Estado;
            pedidoHeaderDb.CodigoPostal = PedidoVm.PedidoHeader.CodigoPostal;

            if (!string.IsNullOrEmpty(PedidoVm.PedidoHeader.Transportadora))
            {
                pedidoHeaderDb.Transportadora = PedidoVm.PedidoHeader.Transportadora;
            }
            if (!string.IsNullOrEmpty(PedidoVm.PedidoHeader.NumeroRastreio))
            {
                pedidoHeaderDb.Transportadora = PedidoVm.PedidoHeader.NumeroRastreio;
            }
            _unitOfWork.PedidoHeader.Update(pedidoHeaderDb);
            _unitOfWork.Save();

            TempData["Success"] = "Detalhes de pedido atualizados com sucesso!";


            return RedirectToAction(nameof(Detalhes), new { pedidoId = pedidoHeaderDb.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Administrador + "," + SD.Role_Empregado)]
        public IActionResult ProcessarPedido()
        {
            _unitOfWork.PedidoHeader.UpdateStatus(PedidoVm.PedidoHeader.Id, SD.StatusInProcess);
            _unitOfWork.Save();
            TempData["Success"] = "Processamento do pedido concluído com sucesso!";
            return RedirectToAction(nameof(Detalhes), new { pedidoId = PedidoVm.PedidoHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Administrador + "," + SD.Role_Empregado)]
        public IActionResult EnviarPedido()
        {
            var orderHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == PedidoVm.PedidoHeader.Id);
            orderHeader.NumeroRastreio = PedidoVm.PedidoHeader.NumeroRastreio;
            orderHeader.Transportadora = PedidoVm.PedidoHeader.Transportadora;
            orderHeader.StatusPedido = SD.StatusShipped;
            orderHeader.DataEnvio = DateTime.Now;
            if (orderHeader.StatusPagamento == SD.PaymentStatusDelayedPayment)
            {
                orderHeader.DataVencimentoPagamento = DateTime.Now.AddDays(30);
            }

            _unitOfWork.PedidoHeader.Update(orderHeader);
            _unitOfWork.Save();
            TempData["Success"] = "Encomenda enviada com sucesso!";
            return RedirectToAction(nameof(Detalhes), new { pedidoId = PedidoVm.PedidoHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Administrador + "," + SD.Role_Empregado)]
        public IActionResult CancelarPedido()
        {
            var orderHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == PedidoVm.PedidoHeader.Id);

            if (orderHeader.StatusPedido == SD.PaymentStatusApproved)
            {
                var options = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentIntentId
                };

                var service = new RefundService();
                Refund refund = service.Create(options);

                _unitOfWork.PedidoHeader.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusRefunded);
            }
            else
            {
                _unitOfWork.PedidoHeader.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusCancelled);
            }
            _unitOfWork.Save();
            TempData["Success"] = "Pedido cancelado com sucesso!";
            return RedirectToAction(nameof(Detalhes), new { pedidoId = PedidoVm.PedidoHeader.Id });

        }

        [ActionName("Detalhes")]
        [HttpPost]
        public IActionResult Detalhes_PAY_NOW()
        {
            PedidoVm.PedidoHeader = _unitOfWork.PedidoHeader
                .GetFirstOrDefault(u => u.Id == PedidoVm.PedidoHeader.Id, includeProperties: "ApplicationUser");
            PedidoVm.PedidoDetalhe = _unitOfWork.PedidoDetalhes
                .GetAll(u => u.PedidoHeaderId == PedidoVm.PedidoHeader.Id, includeProperties: "Bicicleta");

            // STRIPE
            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"admin/pedido/ConfirmacaoPagamento?pedidoHeaderId={PedidoVm.PedidoHeader.Id}",
                CancelUrl = domain + $"admin/pedido/detalhes?pedidoId={PedidoVm.PedidoHeader.Id}",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in PedidoVm.PedidoDetalhe)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Preco * 100),
                        Currency = "brl",
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
            _unitOfWork.PedidoHeader.UpdateStripePaymentID(PedidoVm.PedidoHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303); // Redirect to Url
        }

        public IActionResult ConfirmacaoPagamento(int pedidoHeaderId)
        {
            PedidoHeader pedidoHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == pedidoHeaderId);

            // Companies only
            if (pedidoHeader.StatusPagamento == SD.PaymentStatusDelayedPayment)
            {
                var service = new SessionService();
                Session session = service.Get(pedidoHeader.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.PedidoHeader.UpdateStripePaymentID(pedidoHeaderId, session.Id, session.PaymentIntentId);
                    _unitOfWork.PedidoHeader.UpdateStatus(pedidoHeaderId, pedidoHeader.StatusPedido, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
                }
            }
            return View(pedidoHeaderId);
        }

        public IActionResult AvaliarPedido(int pedidoId)
        {
            PedidoVm = new()
            {
                PedidoHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == pedidoId, includeProperties: "ApplicationUser"),
                PedidoDetalhe = _unitOfWork.PedidoDetalhes.GetAll(u => u.PedidoHeaderId == pedidoId, includeProperties: "Bicicleta")
            };
            return View(PedidoVm);
        }

        [HttpPost]
        public IActionResult AvaliarPedido(int rating, string comment, int pedidoDetalheId)
        {
            var pedidoDetalhe = _unitOfWork.PedidoDetalhes.GetFirstOrDefault(e => e.Id == pedidoDetalheId);


            Avaliacao avaliacao = new Avaliacao()
            {
                PedidoHeaderId = pedidoDetalhe.PedidoHeaderId,
                AvaliacaoCompra = rating,
                ComentarioCompra = comment,
                BicicletaId = pedidoDetalhe.BicicletaId,
                DataAvaliacao = DateTime.Now,
                CriadoEm = DateTime.Now

            };

            _unitOfWork.Avaliacao.Add(avaliacao);
            _unitOfWork.Save();
            return RedirectToAction(nameof(AvaliarPedido),1);
            //PedidoVm = new()
            //{
            //    PedidoHeader = _unitOfWork.PedidoHeader.GetFirstOrDefault(u => u.Id == pedidoId, includeProperties: "ApplicationUser"),
            //    PedidoDetalhe = _unitOfWork.PedidoDetalhes.GetAll(u => u.PedidoHeaderId == pedidoId, includeProperties: "Bicicleta")
            //};
            //return View(PedidoVm);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<PedidoHeader> pedidoHeaders;

            if (User.IsInRole(SD.Role_Administrador) || User.IsInRole(SD.Role_Empregado))
            {
                pedidoHeaders = _unitOfWork.PedidoHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                pedidoHeaders = _unitOfWork.PedidoHeader.GetAll(u => u.ApplicationUserId == userId, includeProperties: "ApplicationUser");
            }

            switch (status)
            {
                case "pendente":
                    pedidoHeaders = pedidoHeaders.Where(x => x.StatusPagamento == SD.PaymentStatusPending);
                    break;
                case "processando":
                    pedidoHeaders = pedidoHeaders.Where(x => x.StatusPagamento == SD.StatusInProcess);
                    break;
                case "completado":
                    pedidoHeaders = pedidoHeaders.Where(x => x.StatusPagamento == SD.StatusShipped);
                    break;
                case "aprovado":
                    pedidoHeaders = pedidoHeaders.Where(x => x.StatusPagamento == SD.StatusApproved);
                    break;
                default:
                    break;
            }
            return Json(new { data = pedidoHeaders });
        }
        #endregion
    }
}
